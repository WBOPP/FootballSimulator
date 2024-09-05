using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootBallGameReal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            remainingTime = 5*60;

            // Set up the timer
            countdownTimer = new Timer();
            countdownTimer.Interval = 1000; // Timer tick interval in milliseconds (1000 ms = 1 second)
            countdownTimer.Tick += CountdownTimer_Tick;
            countdownTimer.Start();
        }
        private Label countdownLabel;
        private Timer countdownTimer;
        private int remainingTime;

        private int quarter = 1;
        private Random random = new Random();
        private int distance = 1;
        private int distancetoGoal = 60;
        private int down = 1;
        private int distDown = 10;
        private int awayscore = 0;
        private int homescore = 0;
        private int randnum = 0;
        bool turnOver = false;
        private int qNum = 2;

        //throw Ball deep
        private void button1_Click(object sender, EventArgs e)
        {


            switch (random.Next(1, 5))
            {
                case 1:
                case 2:
                    // Ball Cought and random distance traveled
                    distance = random.Next(1, distancetoGoal);
                    result.Text =$"You threw the ball {distance} yards";
                    distancetoGoal = distancetoGoal - distance;


                    if (distancetoGoal <= 0)
                    {
                        result.Text ="Touchdown!!!";
                        homescore += 7;
                        homeScore.Text = homescore.ToString();
                        Task.Delay(2000);
                        turnOver = true;

                    }

                    // down and distance calculations

                    break;
                case 3:
                case 4: // Ball dropped
                    distance = 0;
                    result.Text = "The ball was dropped";
                    break;

                case 5: // ball intersepted
                    result.Text = "You turned the ball over, Hopefully defence is good";
                    Task.Delay(2000);
                    turnOver = true;


                    break;

            }

            if (distancetoGoal > 50)
            {

                distanceToHole.Text =$"Ball on the Opposite {100 - distancetoGoal}";
            }
            else
            {
                distanceToHole.Text =$"Ball on the {distancetoGoal}";
            }

            if (down >= 4)
            {
                //turn ball over
                result.Text = "You turned the ball over, Hopefully defence is good";
                Task.Delay(2000);
                turnOver = true;

            }


            else if (down <= 4)
            {


                distDown = distDown - distance;
                if (distance == 0)
                {
                    down += 1;
                    distDown = distDown - distance;
                }
                else if (distance > distDown)
                {
                    down = 1;
                    distDown = 10;
                    downAndDistance.Text = "1st and 10";
                }
                else if (distance < distDown)
                {
                    down += 1;
                }
            }
            if (distancetoGoal <10)
            {
                switch (down)
                {

                    case 2:
                        downAndDistance.Text = "2nd and goal";
                        break;
                    case 3:
                        downAndDistance.Text = "3rd and goal";
                        break;
                    case 4:
                        downAndDistance.Text = $"4th and goal";
                        break;
                    default:
                        downAndDistance.Text = $"1st and goal";
                        break;

                }
            }
            else
            {
                switch (down)
                {

                    case 2:
                        downAndDistance.Text = $"2nd and {distDown}";
                        break;
                    case 3:
                        downAndDistance.Text = $"3rd and {distDown}";
                        break;
                    case 4:
                        downAndDistance.Text = $"4th and {distDown}";
                        break;
                    case 5:
                         result.Text = "You turned the ball over, Hopefully defence is good";
                        Task.Delay(2000);
                        turnOver = true;
                        break;
                }
            }
            if (turnOver == true)
            {
                int numRan5 = 0;
                numRan5 = random.Next(1, 3);
                switch (numRan5)
                {
                    case 1:
                        // othe team scores
                        awayscore += 7;
                        awayScore.Text = awayscore.ToString();
                        distancetoGoal = random.Next(50, 100);
                        result.Text = "Other Team Scores";


                        break;
                    case 2:
                        // other team is stoped
                        distancetoGoal = random.Next(50, 100);


                        result.Text = "Defence stopped the other team";
                        break;
                    case 3: //turnover
                        distancetoGoal = random.Next(10, 50);


                        result.Text = "Other team turned the ball over";
                        break;
                    default:
                        break;

                }
                if (distancetoGoal > 50)
                {

                    distanceToHole.Text =$"Ball on the Opposite {100 - distancetoGoal}";
                }
                else
                {
                    distanceToHole.Text =$"Ball on the {distancetoGoal}";
                }
                turnOver = false;
                downAndDistance.Text = "1st and 10";

                down = 1;
                distDown = 10;
            }
        }
        //Throw ball Medium
        private void button2_Click(object sender, EventArgs e)
        {
            switch (random.Next(1, 5))
            {
                case 1:
                case 2:
                    // Ball Cought and random distance traveled
                    distance = random.Next(1, 30);
                    result.Text =$"You threw the ball {distance} yards";
                    distancetoGoal = distancetoGoal - distance;


                    if (distancetoGoal <= 0)
                    {
                        result.Text ="Touchdown!!!";
                        homescore += 7;
                        homeScore.Text = homescore.ToString();
                        Task.Delay(2000);
                        turnOver = true;
                        break;
                    }

                    // down and distance calculations


                    break;
                case 3:
                case 4: // Ball dropped
                    distance = 0;
                    result.Text = "Ball dropped";

                    break;

                case 5: // ball intersepted
                    result.Text = "You turned the ball over, Hopefully defence is good";
                    Task.Delay(2000);
                    turnOver = true;
                    break;

            }

            if (distancetoGoal > 50)
            {

                distanceToHole.Text =$"Ball on the Opposite {100 - distancetoGoal}";
            }
            else if (distancetoGoal <= 50)
            {
                distanceToHole.Text = $"Ball on the {distancetoGoal}";
            }

            if (down > 4)
            {
                //turn ball over
                result.Text = "You turned the ball over, Hopefully defence is good";
                Task.Delay(2000);
                turnOver = true;
            }


            else if (down <= 4)
            {


                distDown = distDown - distance;
                if (distance == 0)
                {



                    down += 1;
                    distDown = distDown - distance;

                }
                else if (distance > distDown)
                {
                    down = 1;
                    distDown = 10;
                    downAndDistance.Text = "1st and 10";


                }
                else if (distance < distDown)
                {
                    down += 1;



                }
            }

            if (distancetoGoal <10)
            {
                switch (down)
                {

                    case 2:
                        downAndDistance.Text = "2nd and goal";
                        break;
                    case 3:
                        downAndDistance.Text = "3rd and goal";
                        break;
                    case 4:
                        downAndDistance.Text = $"4th and goal";
                        break;
                    default:
                        downAndDistance.Text = $" 1st and goal";
                        break;

                }
            }
            else
            {
                switch (down)
                {

                    case 2:
                        downAndDistance.Text = $"2nd and {distDown}";
                        break;
                    case 3:
                        downAndDistance.Text = $"3rd and {distDown}";
                        break;
                    case 4:
                        downAndDistance.Text = $"4th and {distDown}";
                        break;
                    default:
                        down = 1;
                        break;
                }
            }
            if (turnOver == true)
            {
                int numRan5 = 0;
                numRan5 = random.Next(1, 3);
                switch (numRan5)
                {
                    case 1:
                        // othe team scores
                        awayscore += 7;
                        awayScore.Text = awayscore.ToString();
                        distancetoGoal = random.Next(50, 100);
                        result.Text = "Other Team Scores";


                        break;
                    case 2:
                        // other team is stoped
                        distancetoGoal = random.Next(50, 100);


                        result.Text = "Defence stopped the other team";
                        break;
                    case 3: //turnover
                        distancetoGoal = random.Next(10, 50);


                        result.Text = "Other team turned the ball over";
                        break;
                    default:
                        break;

                }
                if (distancetoGoal > 50)
                {

                    distanceToHole.Text =$"Ball on the Opposite {100 - distancetoGoal}";
                }
                else
                {
                    distanceToHole.Text =$"Ball on the {distancetoGoal}";
                }
                turnOver = false;
                downAndDistance.Text = "1st and 10";

                down = 1;
                distDown = 10;

            }
        }
        // Throw ball Short
        private void button3_Click(object sender, EventArgs e)
        {
            switch (random.Next(1, 5))
            {
                case 1:
                case 2:
                    // Ball Cought and random distance traveled
                    distance = random.Next(1, 10);
                    result.Text =$"You threw the ball {distance} yards";
                    distancetoGoal = distancetoGoal - distance;


                    if (distancetoGoal <= 0)
                    {
                        result.Text ="Touchdown!!!";
                        homescore += 7;
                        homeScore.Text = homescore.ToString();
                        Task.Delay(2000);
                        turnOver = true;
                        break;
                    }

                    // down and distance calculations

                    break;
                case 3:
                case 4: // Ball dropped
                    distance = 0;
                    result.Text ="Ball Dropped";
                    break;

                case 5: // ball intersepted
                    result.Text = "You turned the ball over, Hopefully defence is good";
                    Task.Delay(2000);
                    turnOver = true;
                    break;

            }

            if (distancetoGoal > 50)
            {

                distanceToHole.Text =$"Ball on the Opposite {100 - distancetoGoal}";
            }
            else if (distancetoGoal <= 50)
            {
                distanceToHole.Text = $"Ball on the {distancetoGoal}";
            }

            if (down > 4)
            {
                //turn ball over
                result.Text = "You turned the ball over, Hopefully defence is good";
                Task.Delay(2000);
                turnOver = true;
            }


            else if (down <= 4)
            {


                distDown = distDown - distance;
                if (distance == 0)
                {



                    down += 1;
                    distDown = distDown - distance;

                }
                else if (distance > distDown)
                {
                    down = 1;
                    distDown = 10;
                    downAndDistance.Text = "1st and 10";


                }
                else if (distance < distDown)
                {
                    down += 1;



                }
            }

            if (distancetoGoal <10)
            {
                switch (down)
                {

                    case 2:
                        downAndDistance.Text = "2nd and goal";
                        break;
                    case 3:
                        downAndDistance.Text = "3rd and goal";
                        break;
                    case 4:
                        downAndDistance.Text = $"4th and goal";
                        break;
                    default:
                        downAndDistance.Text = $"1st and goal";
                        break;

                }
            }
            else
            {
                switch (down)
                {

                    case 2:
                        downAndDistance.Text = $"2nd and {distDown}";
                        break;
                    case 3:
                        downAndDistance.Text = $"3rd and {distDown}";
                        break;
                    case 4:
                        downAndDistance.Text = $"4th and {distDown}";
                        break;
                    default:
                        down = 1;
                        break;
                }
            }
            if (turnOver == true)
            {
                int numRan5 = 0;
                numRan5 = random.Next(1, 3);
                switch (numRan5)
                {
                    case 1:
                        // othe team scores
                        awayscore += 7;
                        awayScore.Text = awayscore.ToString();
                        distancetoGoal = random.Next(50, 100);
                        result.Text = "Other Team Scores";


                        break;
                    case 2:
                        // other team is stoped
                        distancetoGoal = random.Next(50, 100);


                        result.Text = "Defence stopped the other team";
                        break;
                    case 3: //turnover
                        distancetoGoal = random.Next(10, 50);


                        result.Text = "Other team turned the ball over";
                        break;
                    default:
                        break;

                }
                if (distancetoGoal > 50)
                {

                    distanceToHole.Text =$"Ball on the Opposite {100 - distancetoGoal}";
                }
                else
                {
                    distanceToHole.Text =$"Ball on the {distancetoGoal}";
                }
                turnOver = false;
                downAndDistance.Text = "1st and 10";

                down = 1;
                distDown = 10;
            }
        }
        // Run Ball
        private void button4_Click(object sender, EventArgs e)
        {
            switch (random.Next(1, 5))
            {
                case 1:
                case 2:
                    // run and random distance traveled
                    distance = random.Next(1, distancetoGoal);
                    result.Text =$"You ran the ball {distance} yards";
                    distancetoGoal = distancetoGoal - distance;


                    if (distancetoGoal <= 0)
                    {
                        result.Text ="Touchdown!!!";
                        homescore += 7;
                        homeScore.Text = homescore.ToString();
                        Task.Delay(2000);
                        turnOver = true;
                        break;
                    }

                    // down and distance calculations

                    break;
                case 3:
                case 4: // run stopped
                    distance = 0;
                    result.Text ="Run Stopped with no gain";
                    break;

                case 5: // ball fumbled
                    result.Text = "You turned the ball over, Hopefully defence is good";
                    Task.Delay(2000);
                    turnOver = true;
                    break;

            }

            if (distancetoGoal > 50)
            {

                distanceToHole.Text =$"Ball on the Opposite {100 - distancetoGoal}";
            }
            else if (distancetoGoal <= 50)
            {
                distanceToHole.Text = $"Ball on the {distancetoGoal}";
            }

            if (down > 4)
            {
                //turn ball over
                result.Text = "You turned the ball over, Hopefully defence is good";
                Task.Delay(2000);

                turnOver = true;
            }


            else if (down <= 4)
            {


                distDown = distDown - distance;
                if (distance == 0)
                {



                    down += 1;
                    distDown = distDown - distance;

                }
                else if (distance > distDown)
                {
                    down = 1;
                    distDown = 10;
                    downAndDistance.Text = "1st and 10";


                }
                else if (distance < distDown)
                {
                    down += 1;



                }
            }

            if (distancetoGoal <10)
            {
                switch (down)
                {

                    case 2:
                        downAndDistance.Text = "2nd and goal";
                        break;
                    case 3:
                        downAndDistance.Text = "3rd and goal";
                        break;
                    case 4:
                        downAndDistance.Text = $"4th and goal";
                        break;
                    default:
                        downAndDistance.Text = $"1st and goal";
                        break;

                }
            }
            else
            {
                switch (down)
                {

                    case 2:
                        downAndDistance.Text = $"2nd and {distDown}";
                        break;
                    case 3:
                        downAndDistance.Text = $"3rd and {distDown}";
                        break;
                    case 4:
                        downAndDistance.Text = $"4th and {distDown}";
                        break;
                    default:
                        down = 1;
                        break;
                }
            }
            if (turnOver == true)
            {
                int numRan5 = 0;
                numRan5 = random.Next(1, 3);
                switch (numRan5)
                {
                    case 1:
                        // othe team scores
                        awayscore += 7;
                        awayScore.Text = awayscore.ToString();
                        distancetoGoal = random.Next(50, 100);
                        result.Text = "Other Team Scores";


                        break;
                    case 2:
                        // other team is stoped
                        distancetoGoal = random.Next(50, 100);


                        result.Text = "Defence stopped the other team";
                        break;
                    case 3: //turnover
                        distancetoGoal = random.Next(10, 50);


                        result.Text = "Other team turned the ball over";
                        break;
                    default:
                        break;

                }
                if (distancetoGoal > 50)
                {

                    distanceToHole.Text =$"Ball on the Opposite {100 - distancetoGoal}";
                }
                else
                {
                    distanceToHole.Text =$"Ball on the {distancetoGoal}";
                }
                turnOver = false;
                downAndDistance.Text = "1st and 10";

                down = 1;
                distDown = 10;

            }





        }
        // Kick Punt Ball
        private void button5_Click(object sender, EventArgs e)
        {
            int numRan5 = 0;
            numRan5 = random.Next(1, 3);
            switch (numRan5)
            {
                case 1:
                    // othe team scores
                    awayscore += 7;
                    awayScore.Text = awayscore.ToString();
                    distancetoGoal = random.Next(50, 100);
                    result.Text = "Other Team Scores";


                    break;
                case 2:
                    // other team is stoped
                    distancetoGoal = random.Next(50, 100);


                    result.Text = "Defence stopped the other team";
                    break;
                case 3: //turnover
                    distancetoGoal = random.Next(10, 50);


                    result.Text = "Other team turned the ball over";
                    break;
                default:
                    break;

            }
            if (distancetoGoal > 50)
            {

                distanceToHole.Text =$"Ball on the Opposite {100 - distancetoGoal}";
            }
            else
            {
                distanceToHole.Text =$"Ball on the {distancetoGoal}";
            }
            turnOver = false;
            downAndDistance.Text = "1st and 10";

            down = 1;
            distDown = 10;
        }
        private void label18_Click(object sender, EventArgs e)
        {

        }
        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            // Decrement the remaining time
            remainingTime--;

            // Calculate minutes and seconds
            int minutes = remainingTime / 60;
            int seconds = remainingTime % 60;

            // Update the label text
            timer.Text = $"{minutes:D2}:{seconds:D2}";
            if (remainingTime <= 0)
            {
                countdownTimer.Stop(); // Stop the timer
                qNum = qNum + 1;
                quarterNum.Text = $"Quarter {qNum}";
                remainingTime  = 5*60;
                countdownTimer.Start();
            }
            if (qNum >4)
            {
                distance = 1;
                distancetoGoal = 60;
                down = 1;
                distDown = 10;
                awayscore = 0;
                homescore = 0;
                randnum = 0;
                turnOver = false;
                qNum = 1;

            }
        }
    }
    }

