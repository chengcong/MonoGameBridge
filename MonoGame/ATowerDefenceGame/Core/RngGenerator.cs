
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ATowerDefenceGame
{
    static class RngGenerator
    {
        public static float GetFloat()
        {
            return (GetUInt32() % 100f) / 100f;
        }

        public static uint GetUInt32()
        {
            return (uint)(new Random()).Next();
        }

        public static bool GetBool()
        {
            return (new Random()).Next() % 2 == 0;
        }
    }
}