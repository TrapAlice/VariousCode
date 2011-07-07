using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Animation
{
	class Ani
	{
		public enum Action
		{
			Idle=0,
			Attack,
			Guard,
			Victory,
			Hit,
			Death,
			Weak,
		}

		private Texture2D mSheet;
		private int mWidth;
		private int mHeight;
		private int mPos;
		private float mTimer;
		private float mInterval;
		private bool mLoop;
		private int mLoopFrom;

		public int Frames { get; set; }
		public int CurrentFrame { get; set; }
		public float Scale { get; set; }


		public Ani(Texture2D pSheet, int pPos, int pWidth, int pHeight, int pFrames, float pInterval)
		{
			mLoop = true;
			CurrentFrame = 0;
			mTimer = 0;
			Scale = 1;
			mLoopFrom = 0;

			mSheet = pSheet;
			mWidth = pWidth;
			mHeight = pHeight;
			Frames = pFrames;
			mInterval = pInterval;
			mPos = pPos;
		}

		public Ani(Texture2D pSheet, int pPos, int pWidth, int pHeight, int pFrames, float pInterval, bool pLoop) :
			this( pSheet, pPos, pWidth, pHeight, pFrames, pInterval )
		{
			mLoop = pLoop;
		}

		public Ani(Texture2D pSheet, int pPos, int pWidth, int pHeight, int pFrames, float pInterval, int pLoopFrom) :
			this( pSheet, pPos, pWidth, pHeight, pFrames, pInterval )
		{
			mLoopFrom = pLoopFrom;
		}

		public void draw(float pTime, Vector2 pPosition, bool pFlip)
		{
			Rectangle sprite = new Rectangle( ( CurrentFrame ) * mWidth, ( mPos - 1 ) * mHeight, mWidth, mHeight );
			Vis.Draw( mSheet, pPosition, sprite, pFlip );
			mTimer += pTime;
			if ( mTimer >= mInterval ) { CurrentFrame++; mTimer = 0; }
			if ( CurrentFrame >= Frames )
			{
				if ( mLoop ) { CurrentFrame = mLoopFrom; }
				else { CurrentFrame = Frames - 1; }
			}
		}

		public bool Finished
		{
			get
			{
				if ( CurrentFrame >= Frames - 1 ) return true;
				return false;
			}
		}

		public void reset()
		{
			CurrentFrame = 0;
			mTimer = 0;
		}
	}
}