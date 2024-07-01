using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLibrary;


namespace GameWindowsForms
{
    public partial class GameForm : Form
    {

        Game game;
        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            game = Game.GetGameInstance(this);

            Bitmap originalImage = Properties.Resources.Wraith_03_Attack_000;

            int desiredWidth = 175;
            int desiredHeight = 175;

            Bitmap resizedImage = new Bitmap(originalImage, desiredWidth, desiredHeight);

            game.AddGameObject(resizedImage, ObjectType.Hero, 50, 300, new KeyboardMovement(10, new Point(this.Width, this.Height), Properties.Resources.Spells_Effect, this), 1000);
            game.AddGameObject(Properties.Resources.Character2_face1, ObjectType.Enemy, 100, 100, new HorizontalMovement(10, new Point(this.Width, this.Height), HorizontalDirection.Left), 1000);
            game.AddGameObject(Properties.Resources.Character8_face1, ObjectType.Enemy, 500, 0, new HorizontalMovement(10, new Point(this.Width, this.Height), HorizontalDirection.Left), 1000);

            CollisionDetection hDidIt = new CollisionDetection(ObjectType.HeroFire, ObjectType.Enemy, CollisionAction.ReduceEnemyHealth);
            CollisionDetection e1DidIt = new CollisionDetection(ObjectType.EnemyFire, ObjectType.Hero, CollisionAction.ReduceHeroHealth);
            CollisionDetection e2DidIt = new CollisionDetection(ObjectType.EnemyFire, ObjectType.Hero, CollisionAction.ReduceHeroHealth);

            game.AddCollisionDetections(hDidIt);
            game.AddCollisionDetections(e1DidIt);
            game.AddCollisionDetections(e2DidIt);

        }

        private void GameLoop_Tick(object sender, EventArgs e)
        {
            game.RemoveGameObject();
            game.Update();

            if (!game.AreEnemyAlive())
            {
                GameLoop.Enabled = false;
                this.Close();
                WinningForm win = new WinningForm();
                win.Show();
            }
            else if (!game.IsHeroAlive())
            {
                GameLoop.Enabled = false;
                this.Close();
                EndGame endGame = new EndGame();
                endGame.Show();
            }
            else
            {
                SetLabel();
            }
          }


        private void SetLabel()
        {
            healthLabel.Text = "HEALTH: " + game.GetHeroObject().GetHealth().ToString();
            HeroCount.Text = "HeroCount: " + game.GetLivePlayersCount();
            EnemyCount.Text = "EnemyCount: " + game.GetLiveEnemiesCount();

        }


        private void EnemyFireLoop_Tick(object sender, EventArgs e)
        {

            game.FireEnemy(Properties.Resources.Spells_Effect1);
        }

        private void healthLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
