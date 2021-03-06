﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using PressPlay.FFWD.Components;

namespace PressPlay.FFWD
{
    public static class ApplicationSettings
    {
        public static bool ShowComponentProfile = true;
        public static bool ShowTurnOffTime = false;
        public static bool ShowTimeBetweenUpdates = false;
        public static bool ShowRaycastTime = false;
        public static bool ShowParticleAnimTime = false;
        public static bool ShowPerformanceBreakdown = true;
        public static bool ShowFPSCounter = true;
        public static bool ShowBodyCounter = true;
        public static bool ShowDebugDisplays = true;
        public static bool ShowDebugLines = true;
        public static bool ShowDebugPhysics = false;
        public static bool ShowDebugPhysicsCustom = false;
#if WINDOWS
        public static int AssetLoadInterval = 0; // In Milliseconds
#else
        public static int AssetLoadInterval = 50; // In Milliseconds
#endif
        public static bool UseFallbackRendering = false;

        /// <summary>
        /// This can be disabled to avoid moving static colliders, which is pretty expensive.
        /// If you do it a lot, consider flipping this and making the colliders kinematic.
        /// </summary>
        public static bool Physics_MoveStaticColliders = true;

        public static class DefaultCapacities
        {
            /// <summary>
            /// All of these settings can be tuned in order to adjust memory usage of the engine.
            /// You should do this in your game contructor.
            /// </summary>
            #region Default list sizes
            public static int Lights = 4;
            public static int QueryHelper = 20;
            public static int RaycastHits = 20;
            public static int GestureSamples = 4;
            public static int Touches = 4;
            public static int AnimationComponents = 30;
            public static int TransformChanges = 500;
            public static int ComponentLists = 1500;
            public static int RenderQueues = 100;
            public static int RenderCullingQueue = 20;
            public static int ColliderContacts = 50;
            #endregion
        }

        public static class DefaultValues
        {
            public static float MinimumNearClipPlane = 0.1f;
            public static float StaticBatchTileSize = 100.0f;
        }

    }
}
