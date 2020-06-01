using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using Robocode;
using Robocode.Util;


namespace M1IL
{
    public class StarPlatinum : TeamRobot
    {
        //vars
        private int dist = 50; // distance to move when we're hit

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
            
           
            // Move to that wall
            Ahead(50);
            // Turn gun to starting point
            TurnGunRight(90);
        }

        public void SmartFire(double robotDistance)

        {
            if (robotDistance > 200 || Energy < 15)
            {
                Fire(1);
                Back(25);
            }
            else if (robotDistance > 50)
            {
                Fire(2);
                Back(30);
            }
            else
            {
                Fire(3);
                Back(50);
            }
        }

        public override void OnScannedRobot(ScannedRobotEvent e)
        {
            // Calculate exact location of the robot
            double absoluteBearing = Heading + e.Bearing;
            double bearingFromGun = Utils.NormalRelativeAngleDegrees(absoluteBearing - GunHeading);

            // If it's close enough, fire!
            if (Math.Abs(bearingFromGun) <= 3)
            {
                TurnGunRight(bearingFromGun);
                // We check gun heat here, because calling Fire()
                // uses a turn, which could cause us to lose track
                // of the other robot.
                if (GunHeat == 0 && !IsTeammate(e.Name))
                {
                    SmartFire(e.Distance);
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

        public override void OnHitByBullet(HitByBulletEvent e)
        {
            TurnRight(Utils.NormalRelativeAngleDegrees(90 - (Heading - e.Heading)));
            TurnGunRight(e.HeadingRadians);

            Ahead(dist);
            dist *= -1;;
        }


        public override void OnHitRobot(HitRobotEvent e)
        {
            if (e.Bearing >= 0)
            {
                TurnRight(5 * 1);
            }
            else
            {
                TurnRight(5 * -1);
            }
            TurnRight(e.Bearing);

            // Determine a shot that won't kill the robot...
            // We want to ram him instead for bonus points
            
            Back(500); // Ram him again!
        }

        public override void OnHitWall(HitWallEvent e)
        {
            Back(120);
            TurnGunLeft(180);
        }



    }
}
