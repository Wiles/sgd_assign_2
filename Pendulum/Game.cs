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
using Timer = Pend.Timer;

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
        static string gametitle  = "Pendulum";
        static int screenwidth   = 640;
        static int screenheight  = 480;
        static bool windowed     = true;
        static bool graphicslost = false;
        static Timer gametimer   = null;
        static bool paused       = false;
        
        // --------------------------------------------------------------------
        // Devices
        // --------------------------------------------------------------------
        Microsoft.DirectX.Direct3D.Device graphics        = null;
        Microsoft.DirectX.DirectSound.Device sound        = null;
        Microsoft.DirectX.DirectInput.Device keyboard     = null;
        Microsoft.DirectX.DirectInput.Device mouse        = null;
        Microsoft.DirectX.DirectInput.Device gameinput    = null;

        //
        // Sprites
        //
        Pend.Pendulum sShip = null;

        //
        // resources
        //
        Microsoft.DirectX.DirectSound.SecondaryBuffer wave = null;

        // --------------------------------------------------------------------
        // Game constructor
        // --------------------------------------------------------------------
        public Game()
        {
            this.ClientSize = new System.Drawing.Size( screenwidth, screenheight );
            this.Text = gametitle;
            gametimer = new Timer();
        }
        

        // --------------------------------------------------------------------
        // Initialize the Direct3D Graphics subsystem
        // --------------------------------------------------------------------
        public void InitializeGraphics()
        {
            // set up the parameters
            Microsoft.DirectX.Direct3D.PresentParameters p = new Microsoft.DirectX.Direct3D.PresentParameters();
            p.SwapEffect = Microsoft.DirectX.Direct3D.SwapEffect.Discard;

            
            if( windowed == true )
            {
                p.Windowed = true;
            }
            else
            {
                // get the current display mode:
                Microsoft.DirectX.Direct3D.Format current = Microsoft.DirectX.Direct3D.Manager.Adapters[0].CurrentDisplayMode.Format;
            	
                // set up a fullscreen display device
                p.Windowed = false;                 // fullscreen
                p.BackBufferCount = 1;              // one back buffer
                p.BackBufferFormat = current;       // use current format
                p.BackBufferWidth = screenwidth;
                p.BackBufferHeight = screenheight;
            }

            // create a new device:
            graphics = new Microsoft.DirectX.Direct3D.Device( 
                0, 
                Microsoft.DirectX.Direct3D.DeviceType.Hardware, 
                this, 
                Microsoft.DirectX.Direct3D.CreateFlags.SoftwareVertexProcessing, 
                p );


            // Setup the event handlers for the device
            graphics.DeviceLost     += new EventHandler( this.InvalidateDeviceObjects );
            graphics.DeviceReset    += new EventHandler( this.RestoreDeviceObjects );
            graphics.Disposing      += new EventHandler( this.DeleteDeviceObjects );
            graphics.DeviceResizing += new CancelEventHandler( this.EnvironmentResizing );

            // Set up the local sprites
            Microsoft.DirectX.Direct3D.Texture texture = Microsoft.DirectX.Direct3D.TextureLoader.FromFile(graphics, "..\\..\\Pendulum.png", 100, 300, 0, 0, Microsoft.DirectX.Direct3D.Format.Unknown, Microsoft.DirectX.Direct3D.Pool.Managed,
                Microsoft.DirectX.Direct3D.Filter.Linear, Microsoft.DirectX.Direct3D.Filter.Linear, Color.White.ToArgb());
            sShip = new Pend.Pendulum(graphics, this.ClientSize, texture, wave);

        }


        // --------------------------------------------------------------------
        // Initialize the DirectSound subsystem
        // --------------------------------------------------------------------
        public void InitializeSound()
        {
            // set up a device
            sound = new Microsoft.DirectX.DirectSound.Device();
            sound.SetCooperativeLevel( this, Microsoft.DirectX.DirectSound.CooperativeLevel.Normal );
            wave = new Microsoft.DirectX.DirectSound.SecondaryBuffer("..\\..\\air_whoosh.wav", sound);
            wave.Play(0, Microsoft.DirectX.DirectSound.BufferPlayFlags.Default);
        }

        // --------------------------------------------------------------------
        // Initialize the DirectInput subsystem
        // --------------------------------------------------------------------
        public void InitializeInput()
        {
            // set up the keyboard
            keyboard = new Microsoft.DirectX.DirectInput.Device( Microsoft.DirectX.DirectInput.SystemGuid.Keyboard );
            keyboard.SetCooperativeLevel( 
                this, 
                Microsoft.DirectX.DirectInput.CooperativeLevelFlags.Background |
                Microsoft.DirectX.DirectInput.CooperativeLevelFlags.NonExclusive );
            keyboard.Acquire();

            // set up the mouse
            mouse = new Microsoft.DirectX.DirectInput.Device( Microsoft.DirectX.DirectInput.SystemGuid.Mouse );
            mouse.SetCooperativeLevel( 
                this, 
                Microsoft.DirectX.DirectInput.CooperativeLevelFlags.Background |
                Microsoft.DirectX.DirectInput.CooperativeLevelFlags.NonExclusive );
            mouse.Acquire();


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
            if( !paused )
            {
                //TODO
                sShip.Move(gametimer);

            }
            else
                System.Threading.Thread.Sleep( 1 );
        }
        


        // --------------------------------------------------------------------
        // Render the current game screen
        // --------------------------------------------------------------------
        protected virtual void Render()
        {
            if( graphics != null ) 
            {
                // check to see if the device has been lost. If so, try to get
                // it back.
                if( graphicslost )
                {
                    try
                    {
                        graphics.TestCooperativeLevel();
                    }
                    catch( Microsoft.DirectX.Direct3D.DeviceLostException )
                    {
                        // device cannot be reaquired yet, just return
                        return;
                    }
                    catch( Microsoft.DirectX.Direct3D.DeviceNotResetException )
                    {
                        // device has not been reset, but it can be reaquired now

                        graphics.Reset( graphics.PresentationParameters );
                    }
                    graphicslost = false;
                }


                try
                {

                    graphics.Clear( Microsoft.DirectX.Direct3D.ClearFlags.Target, Color.Blue, 1.0f, 0 );

                    graphics.BeginScene();

                    if (sShip != null)
                    {
                        sShip.Move(gametimer);
                    }
            
                    graphics.EndScene();
                    graphics.Present();
                }

                // device has been lost, and it cannot be re-initialized yet
                catch( Microsoft.DirectX.Direct3D.DeviceLostException )
                {
                    graphicslost = true;
                }
            }
        }



        // --------------------------------------------------------------------
        // Run the game
        // --------------------------------------------------------------------
        public void Run()
        {
            // reset the game timer
            gametimer.Reset();

            // loop while form is valid
            while( this.Created )
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
            this.Text = gametitle + " - Paused";
        }

       
        protected override void OnKeyDown( KeyEventArgs e )
        {
            //base.OnKeyDown( e );

            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == System.Windows.Forms.Keys.P)
            {
                Paused = !Paused;
                if (Paused)
                {
                    this.Text = gametitle + " - Paused";
                }
                else
                {
                    this.Text = gametitle;
                }
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
            get { return paused; }
            set 
            {
                // pause the game
                if( value == true && paused == false )
                {
                    gametimer.Pause();
                    paused = true;
                }

                // unpause the game
                if( value == false && paused == true )
                {
                    gametimer.Unpause();
                    paused = false;
                }
            }
        }


        // --------------------------------------------------------------------
        // Entry point of the program, creates a new game and runs it
        // --------------------------------------------------------------------
        static void Main()
        {
            Game game;
            try
            {
                game = new Game();
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
