// Beginning C# Game Programming
// (C)2004 Ron Penton
// Advanced Framework Timer

namespace Pend
{

    // --------------------------------------------------------------------
    // Independent timer class
    // --------------------------------------------------------------------
    public class Timer
	{

        // --------------------------------------------------------------------
        // variables
        // --------------------------------------------------------------------
        private float _starttime;    // absolute time when timer was last reset
        private float _pausetime;    // absolute time when timer was paused
        private float _elapsedtime;  // timer time when last Elapsed() call was made
        private bool _paused;        // is timer paused?


        // --------------------------------------------------------------------
        // Returns absolute system time; static; requires no timer objects
        // --------------------------------------------------------------------
        public static float Now()
        {
            return DXUtil.Timer( DirectXTimer.GetAbsoluteTime );
        }

        // --------------------------------------------------------------------
        // Constructor
        // --------------------------------------------------------------------
        public Timer()
		{
            // reset the start time to current absolute time
			_starttime = Now();
            _paused = false;

            // reset elapsed time to 0
            _elapsedtime = 0.0f;
        }


        // --------------------------------------------------------------------
        // Reset the timer to a specific time value
        // --------------------------------------------------------------------
        public void Reset( float pTime )
        {
            _starttime = Now() - pTime;
        }


        // --------------------------------------------------------------------
        // Reset the timer to 0
        // --------------------------------------------------------------------
        public void Reset()
        {
            Reset( 0.0f );
        }


        // --------------------------------------------------------------------
        // get current timer time
        // --------------------------------------------------------------------
        public float Time()
        {
            // if paused, return time difference from when timer was paused
            if( _paused )
                return _pausetime - _starttime;

            // if not, then return time normally
            return Now() - _starttime;
        }


        // --------------------------------------------------------------------
        // get amount of time elapsed since last call to Elapsed()
        // --------------------------------------------------------------------
        public float Elapsed()
        {
            float now = Time();
            float elapsed = now - _elapsedtime;
            _elapsedtime = now;
            return elapsed;
        }


        // --------------------------------------------------------------------
        // Pause the timer
        // --------------------------------------------------------------------
        public void Pause()
        {
            // make sure timer isn't already paused
            if( !_paused )
            {
                _paused = true;
                _pausetime = Now();
            }
        }


        // --------------------------------------------------------------------
        // Unpause the timer
        // --------------------------------------------------------------------
        public void Unpause()
        {
            // make sure timer isn't already unpaused
            if( _paused )
            {
                _paused = false;
                _starttime += Now() - _pausetime;
            }
        }
    }
}
