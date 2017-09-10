namespace XRITTune {
    class CountDown {
        private object lockObj;
        private int count;
        public CountDown() {
            lockObj = new object();
            count = 0;
        }

        public void Inc() {
            lock(lockObj) {
                count++;
            }
        }

        public void Dec() {
            lock (lockObj) {
                count--;
            }
        }

        public bool IsZero() {
            bool ret;
            lock (lockObj) {
                ret = count == 0;
            }
            return ret;
        }
    }
}
