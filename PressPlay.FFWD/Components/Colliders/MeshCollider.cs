﻿using System.Collections.Generic;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PressPlay.FFWD.Components
{
    public class MeshCollider : Collider
    {
        #region ContentProperties
        public short[] triangles { get; set; }
        public Vector3[] vertices { get; set; }
        #endregion

        #region Debug drawing
        //private BasicEffect effect;
        private VertexPositionColor[] pointList;
        #endregion

        public override void Awake()
        {
            base.Awake();
            // For drawing the original mesh
            pointList = new VertexPositionColor[vertices.Length];
            for (int i = 0; i < vertices.Length; i++)
            {
                pointList[i] = new VertexPositionColor(vertices[i], Microsoft.Xna.Framework.Color.LawnGreen);
            }
        }

        internal override void AddCollider(Body body, float mass)
        {
            List<Microsoft.Xna.Framework.Vector2[]> tris = new List<Microsoft.Xna.Framework.Vector2[]>();
            for (int i = 0; i < triangles.Length; i += 3)
            {
                if (vertices[triangles[i]].y + vertices[triangles[i + 1]].y + vertices[triangles[i + 2]].y > 1)
                {
#if DEBUG
                    Debug.Log(" Warning: " + ToString() + " has non zero Y in collider");
#endif
                }
                Microsoft.Xna.Framework.Vector2[] tri = new Microsoft.Xna.Framework.Vector2[] { 
                    new Microsoft.Xna.Framework.Vector2(vertices[triangles[i]].x * transform.lossyScale.x, vertices[triangles[i]].z * transform.lossyScale.z),
                    new Microsoft.Xna.Framework.Vector2(vertices[triangles[i + 2]].x * transform.lossyScale.x, vertices[triangles[i + 2]].z * transform.lossyScale.z),
                    new Microsoft.Xna.Framework.Vector2(vertices[triangles[i + 1]].x * transform.lossyScale.x, vertices[triangles[i + 1]].z * transform.lossyScale.z)
                };
                tris.Add(tri);
            }

            connectedBody = Physics.AddMesh(body, isTrigger, tris, mass);
        }

        public void Select()
        {
            for (int i = 0; i < pointList.Length; i++)
            {
                pointList[i].Color = Microsoft.Xna.Framework.Color.Red;
            }
        }
    }
}
