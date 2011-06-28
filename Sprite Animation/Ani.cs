using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;


namespace Animation
{
    class Ani
    {
        private Texture2D mSheet;
        private int mWidth; private int mHeight;
        private int mFrames;
        private int mCurrentFrame;
        private int mPos;
        private float timer;
        private float mInterval;
        private float mScale;
        private Vector2 mPosition;
        private bool mLoop;

        public Ani(Texture2D pSheet, int pPos, int pWidth, int pHeight, int pFrames, float pInterval)
        {
            mSheet = pSheet;
            mWidth = pWidth;
            mHeight = pHeight;
            mFrames = pFrames;
            mInterval = pInterval;
            mPos = pPos;

            mLoop = true;
            mCurrentFrame = 0;
            timer = 0;
            mScale = 1;
            mPosition = new Vector2(0, 0);
            
        }

        public Ani(Texture2D pSheet, int pPos, int pWidth, int pHeight, int pFrames, float pInterval, bool pLoop)
        {
            mSheet = pSheet;
            mWidth = pWidth;
            mHeight = pHeight;
            mFrames = pFrames;
            mInterval = pInterval;
            mPos = pPos;
            mLoop = pLoop;

            mCurrentFrame = 0;
            timer = 0;
            mScale = 1;
            mPosition = new Vector2(0, 0);
        }

        public void draw(float pTime, bool pFlip)
        {
            Game1.spriteBatch.Begin();

            Rectangle sprite = new Rectangle((mCurrentFrame) * mWidth, (mPos-1) * mHeight, mWidth, mHeight);
            //Game1.spriteBatch.Draw(mSheet, mPosition, sprite, Color.White);
            if(!pFlip)Game1.spriteBatch.Draw(mSheet, mPosition, sprite, Color.White, 0.0f, new Vector2(0, 0), mScale, SpriteEffects.None, 0.5f);
            if (pFlip) Game1.spriteBatch.Draw(mSheet, mPosition, sprite, Color.White, 0.0f, new Vector2(0, 0), mScale, SpriteEffects.FlipHorizontally, 0.5f);

            /*String timerString = "Timer: " +timer.ToString();
            String CurrentFrameString = "Current Frame:" + mCurrentFrame.ToString();
            Game1.spriteBatch.DrawString(Game1.font, timerString, new Vector2(100, 0), Color.Black);
            Game1.spriteBatch.DrawString(Game1.font, CurrentFrameString, new Vector2(100, 20), Color.Black);
            */
            Game1.spriteBatch.End();

            

            timer += pTime;
            if (timer > mInterval) { mCurrentFrame++; timer = 0; }
            if (mCurrentFrame >= mFrames && mLoop) { mCurrentFrame = 0; }
            else if (mCurrentFrame >= mFrames && !mLoop) { mCurrentFrame = mFrames-1; }
        }

        public Vector2 Position
        {
            get
            {
                return mPosition;
            }
            set
            {
                mPosition = value;
            }
        }

        public float Scale
        {
            get
            {
                return mScale;
            }
            set
            {
                mScale = value;
            }
        }
    }
}
