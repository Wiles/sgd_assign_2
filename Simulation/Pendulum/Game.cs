// SET Invader
// Simple game to demonstrate collision
//
// Norbert Mika
// Copyright (c) 2009
// Modified 01 Feb 2010 by NJM
//

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX.DirectSound;
using Device = Microsoft.DirectX.DirectSound.Device;
using Font = Microsoft.DirectX.Direct3D.Font;

namespace Pend
{
    // ------------------------------------------------------------------------
    // The main Game class.
    // ------------------------------------------------------------------------
    public class Game : Form
    {
        // --------------------------------------------------------------------
        // static variables
        // --------------------------------------------------------------------
        private const string Gametitle = "Pendulum";
        private const int Screenwidth = 640;
        private const int Screenheight = 480;
        private static bool _graphicslost;
        private static Timer _gametimer;
        private static bool _paused;
        private Font _font;
        
        // --------------------------------------------------------------------
        // Devices
        // --------------------------------------------------------------------
        private Microsoft.DirectX.Direct3D.Device _graphics;
        private Device _sound;
        private Microsoft.DirectX.DirectInput.Device _keyboard;
        private Microsoft.DirectX.DirectInput.Device _mouse;

        //
        // Sprites
        //
        private Pendulum _pendulum;

        //
        // resources
        //
        private SecondaryBuffer _wave;

        // --------------------------------------------------------------------
        // Game constructor
        // --------------------------------------------------------------------
        public Game()
        {
            ClientSize = new Size( Screenwidth, Screenheight );
            Text = Gametitle;
            _gametimer = new Timer();
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }


        // --------------------------------------------------------------------
        // Initialize the Direct3D Graphics subsystem
        // --------------------------------------------------------------------
        public void InitializeGraphics()
        {
            // set up the parameters
            var p = new PresentParameters {SwapEffect = SwapEffect.Discard, Windowed = true};

            // create a new device:
            _graphics = new Microsoft.DirectX.Direct3D.Device( 
                0, 
                DeviceType.Hardware, 
                this, 
                CreateFlags.SoftwareVertexProcessing, 
                p );


            // Setup the event handlers for the device
            _graphics.DeviceLost     += InvalidateDeviceObjects;
            _graphics.DeviceReset    += RestoreDeviceObjects;
            _graphics.Disposing      += DeleteDeviceObjects;
            _graphics.DeviceResizing += EnvironmentResizing;

            // Set up the local sprites
            var texture = TextureLoader.FromFile(_graphics, "..\\..\\Pendulum.png", 100, 300, 0, 0, Format.Unknown, Pool.Managed,
                Filter.Linear, Filter.Linear, Color.White.ToArgb());
            _pendulum = new Pendulum(_graphics, ClientSize, texture, _wave);

            _font = new Font(_graphics, new System.Drawing.Font("courier new", 12f, FontStyle.Regular));

        }


        // --------------------------------------------------------------------
        // Initialize the DirectSound subsystem
        // --------------------------------------------------------------------
        public void InitializeSound()
        {
            // set up a device
            _sound = new Device();
            _sound.SetCooperativeLevel( this, CooperativeLevel.Normal );
            _wave = new SecondaryBuffer("..\\..\\air_whoosh.wav", _sound);
            _wave.Play(0, BufferPlayFlags.Looping);
        }

        // --------------------------------------------------------------------
        // Initialize the DirectInput subsystem
        // --------------------------------------------------------------------
        public void InitializeInput()
        {
            // set up the keyboard
            _keyboard = new Microsoft.DirectX.DirectInput.Device( Microsoft.DirectX.DirectInput.SystemGuid.Keyboard );
            _keyboard.SetCooperativeLevel( 
                this, 
                Microsoft.DirectX.DirectInput.CooperativeLevelFlags.Background |
                Microsoft.DirectX.DirectInput.CooperativeLevelFlags.NonExclusive );
            _keyboard.Acquire();

            // set up the mouse
            _mouse = new Microsoft.DirectX.DirectInput.Device( Microsoft.DirectX.DirectInput.SystemGuid.Mouse );
            _mouse.SetCooperativeLevel( 
                this, 
                Microsoft.DirectX.DirectInput.CooperativeLevelFlags.Background |
                Microsoft.DirectX.DirectInput.CooperativeLevelFlags.NonExclusive );
            _mouse.Acquire();


        }

        // --------------------------------------------------------------------
        // Device Event Handlers
        // --------------------------------------------------------------------
        protected virtual void InvalidateDeviceObjects( object sender, EventArgs e )
        {
        }
        
        protected virtual void RestoreDeviceObjects( object sender, EventArgs e )
        {
        }
        
        protected virtual void DeleteDeviceObjects( object sender, EventArgs e )
        {
        }
        
        protected virtual void EnvironmentResizing( object sender, CancelEventArgs e )
        {
            e.Cancel = true;
        }
        

        // --------------------------------------------------------------------
        // Process one iteration of the game loop
        // --------------------------------------------------------------------
        protected virtual void ProcessFrame()
        {
            // process the game only while it's not paused
            if( !_paused )
            {
                _pendulum.Move(_gametimer);
            }
            else
                System.Threading.Thread.Sleep( 1 );
        }
        


        // --------------------------------------------------------------------
        // Render the current game screen
        // --------------------------------------------------------------------
        protected virtual void Render()
        {
            if( _graphics != null ) 
            {
                // check to see if the device has been lost. If so, try to get
                // it back.
                if( _graphicslost )
                {
                    try
                    {
                        _graphics.TestCooperativeLevel();
                    }
                    catch( DeviceLostException )
                    {
                        // device cannot be reaquired yet, just return
                        return;
                    }
                    catch( DeviceNotResetException )
                    {
                        // device has not been reset, but it can be reaquired now

                        _graphics.Reset( _graphics.PresentationParameters );
                    }
                    _graphicslost = false;
                }


                try
                {

                    _graphics.Clear( ClearFlags.Target, Color.Blue, 1.0f, 0 );

                    _graphics.BeginScene();

                    if (_pendulum != null)
                    {
                        _pendulum.Move(_gametimer);
                        _font.DrawText(null, string.Format(" Angle: {0:0.0}", _pendulum.MaxAngle), new Point(10, 20), Color.White);
                        _font.DrawText(null, string.Format("Length: {0:0.0}", _pendulum.Length), new Point(10, 40), Color.White);
                    }
            
                    _graphics.EndScene();
                    _graphics.Present();
                }

                // device has been lost, and it cannot be re-initialized yet
                catch( DeviceLostException )
                {
                    _graphicslost = true;
                }
            }
        }



        // --------------------------------------------------------------------
        // Run the game
        // --------------------------------------------------------------------
        public void Run()
        {
            // reset the game timer
            _gametimer.Reset();

            // loop while form is valid
            while( Created )
            {
                if (!Paused)
                {
                    // process one frame of the game
                    ProcessFrame();

                    // render the current scene
                    Render();
                }

                // handle all events
                Application.DoEvents();
            }
        }
        

        // --------------------------------------------------------------------
        // Handle windows events
        // --------------------------------------------------------------------
        protected override void OnLostFocus( EventArgs e )
        {
            base.OnLostFocus( e );
            Paused = true;
            Text = Gametitle + " - Paused";
            _wave.Stop();
        }

       
        protected override void OnKeyDown( KeyEventArgs e )
        {
            //base.OnKeyDown( e );

            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }

            if (e.KeyCode == Keys.P)
            {
                Paused = !Paused;
                if (Paused)
                {
                    Text = Gametitle + " - Paused";
                    _wave.Stop();
                }
                else
                {
                    Text = Gametitle;
                    _wave.Play(0, BufferPlayFlags.Looping);
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                _pendulum.Length -= .1f;
            }
            else if (e.KeyCode == Keys.Down)
            {
                _pendulum.Length += .1f;
            }
            else if (e.KeyCode == Keys.Left)
            {
                _pendulum.MaxAngle -= .5;
            }
            else if (e.KeyCode == Keys.Right)
            {
                _pendulum.MaxAngle += .5;
            }

        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
        }

        // --------------------------------------------------------------------
        // Property to pause/unpause the game, or get its pause state
        // --------------------------------------------------------------------
        public bool Paused
        {
            get { return _paused; }
            set 
            {
                // pause the game
                if( value && _paused == false )
                {
                    _gametimer.Pause();
                    _paused = true;
                }

                // unpause the game
                if( value == false && _paused )
                {
                    _gametimer.Unpause();
                    _paused = false;
                }
            }
        }


        // --------------------------------------------------------------------
        // Entry point of the program, creates a new game and runs it
        // --------------------------------------------------------------------
        static void Main()
        {
            try
            {
                var game = new Game();
                game.InitializeSound();
                game.InitializeGraphics();
                game.InitializeInput();

                game.Show();
                game.Run();
            }
            catch( Exception e )
            {
                MessageBox.Show( "Error: " + e.Message );
            }
        }
    }
}
