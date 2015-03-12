using Gadgeteer;
using Servo_API;
using Button = Gadgeteer.Modules.GHIElectronics.Button;

namespace Program
{
    public partial class Program
    {
        Servo servo; 
        private bool IsRunning;

        void ProgramStarted()
        {
            Debug("Set it UUUUP!");

            // Setup
            Mainboard.SetDebugLED(true);
            button.ButtonPressed += ButtonOnButtonPressed;
        }

        private void ButtonOnButtonPressed(Button sender, Button.ButtonState state)
        {
            if (!IsRunning)
            {
                Debug("Chocolate!");
                
                ledLeft.FadeOnce(Color.Red);
                ledRight.FadeOnce(Color.Red);

                IsRunning = true;

                servo = new Servo(extender);
                servo.Degree = -180;
                servo.Dispose();

                IsRunning = false;

                Debug("Bedtime!");                
            }
        }

        void Debug(string text)
        {
            Microsoft.SPOT.Debug.Print("==> " + text);
        }
    }
}
