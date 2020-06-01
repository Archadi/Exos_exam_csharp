using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robocode;
using Robocode.Util;

namespace Robots
{
    public class MonPremierRobot : Robot
    {
        private bool stopWhenSeeRobot;
        private bool movingForward;

        public override void Run()
        {
            //---Init Robot---
            //set color
            BodyColor = (Color.FromArgb(52, 36, 109));
            GunColor = (Color.FromArgb(255, 215, 0));
            RadarColor = (Color.FromArgb(170, 142, 251));
            BulletColor = (Color.Black);
            ScanColor = (Color.FromArgb(10, 6, 35));


            while (true)
            {
                GoStarPlatinum();
            }
        }

        /// <summary>
        ///   goCorner:  A very inefficient way to get to a corner.  Can you do better?
        /// </summary>
        public void GoStarPlatinum()
        {
            // We don't want to stop when we're just turning...
            stopWhenSeeRobot = false;
            // turn to face the wall to the "right" of our desired corner.
            /*TurnRight(Utils.NormalRelativeAngleDegrees(corner - Heading));
            // Ok, now we don't want to crash into any robot in our way...
            stopWhenSeeRobot = true;*/
            // Move to that wall
            Ahead(5000);
            // Turn to face the corner
            TurnLeft(90);
            // Move to the corner
            Ahead(5000);
            // Turn gun to starting point
            TurnGunLeft(180);
        }

        

        /// <summary>
        ///   smartFire:  Custom Fire method that determines firepower based on distance.
        /// </summary>
        /// <param name="robotDistance">
        ///   the distance to the robot to Fire at
        /// </param>
        public void SmartFire(double robotDistance)

        {
            if (robotDistance > 200 || Energy < 15)
            {
                Fire(1);
                FireBullet(2500);
                Back(2500);
            }
            else if (robotDistance > 50)
            {
                Fire(2);
                FireBullet(3000);
                Back(3000);
            }
            else
            {
                Fire(3);
                FireBullet(5000);
                Back(5000);
            }
        }

        public override void OnScannedRobot(ScannedRobotEvent evnt)
        {
            // Calculate exact location of the robot
            double absoluteBearing = Heading + evnt.Bearing;
            double bearingFromGun = Utils.NormalRelativeAngleDegrees(absoluteBearing - GunHeading);

            // If it's close enough, fire!
            if (Math.Abs(bearingFromGun) <= 3)
            {
                TurnGunRight(bearingFromGun);
                // We check gun heat here, because calling Fire()
                // uses a turn, which could cause us to lose track
                // of the other robot.
                if (GunHeat == 0)
                {
                    SmartFire(evnt.Distance);
                }
            }
            else
            {
                // otherwise just set the gun to turn.
                // Note:  This will have no effect until we call scan()
                TurnGunRight(bearingFromGun);
            }
            // Generates another scan event if we see a robot.
            // We only need to call this if the gun (and therefore radar)
            // are not turning.  Otherwise, scan is called automatically.
            if (bearingFromGun == 0)
            {
                Scan();
            }
           
        }

        public override void OnPaint(IGraphics graphics)
        {
            var transparentGreen = new SolidBrush(Color.FromArgb(30, 0, 0xFF, 0));
            graphics.FillEllipse(transparentGreen, (int)(X - 60), (int)(Y - 60), 120, 120);
            graphics.DrawEllipse(Pens.Red, (int) (X - 500), (int)(X - 500), 100, 100);
        }

        public void ReverseDirection()
        {
            if (movingForward)
            {
                Back(40000);
                TurnGunLeft(90);
                movingForward = false;
            }
            else
            {
                Ahead(40000);
                TurnGunLeft(90);
                movingForward = true;
            }
        }


        public override void OnHitWall(HitWallEvent e)
        {
            // Bounce off!
            ReverseDirection();
        }

        public override void OnHitByBullet(HitByBulletEvent e)
        {
            Scan();
            TurnGunRight(e.Bearing);
            Back(1000);

        }

        public override void OnHitRobot(HitRobotEvent e)
        {
            if (e.Bearing > -90 && e.Bearing <= 90)
            {
                Back(100);
                TurnGunRight(e.Bearing+1);
                Scan();
                TurnGunRight((e.Bearing + 1)* -1);
            }
            else
            {
                Ahead(100);
                TurnGunRight(e.Bearing + 1);
                Scan();
            }
       }

        public override void OnWin(WinEvent e)
        {
            // Victory dance
            TurnRight(36000);
            Console.WriteLine("MODA MODA MODA MODAAAAAAAAA!!!!");
        }
    }
}
