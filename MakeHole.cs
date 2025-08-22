using UnityEngine;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.ProBuilder;
using UnityEngine.ProBuilder.MeshOperations;
namespace UnityEngine.AIMt
{
    public class MakeHole : MonoBehaviour
    {
        public Mesh CSGaim(GameObject Lev, GameObject Prav, bool BoolnAnd)
        {
            Model csg_model_a = new Model(Lev);
            Model csg_model_b = new Model(Prav);

            Node a = new Node(csg_model_a.ToPolygons());
            Node b = new Node(csg_model_b.ToPolygons());
            List<Polygon> polygons;
            if (BoolnAnd == false)
            {
                polygons = Node.Subtract(a, b).AllPolygons();
            }
            else
            {
                polygons = Node.Intersect(a, b).AllPolygons();
            }

            ProBuilderMesh pb = ProBuilderMesh.Create();
            pb.GetComponent<MeshFilter>().sharedMesh = (Mesh)(new Model(polygons));
            MeshImporter importer = new MeshImporter(pb.gameObject);
            importer.Import(new MeshImportSettings() { quads = true, smoothing = true, smoothingAngle = 1f });
            //pb.Rebuild();
            //Vector3 srtCrd = pb.gameObject.transform.position; // 
            pb.CenterPivot(null);

            MeshFilter NewMeshF = pb.GetComponent<MeshFilter>();
            var combine = new CombineInstance[1];
            combine[0].mesh = NewMeshF.sharedMesh;
            NewMeshF.transform.position = NewMeshF.transform.localToWorldMatrix.GetPosition() - Lev.GetComponent<MeshFilter>().transform.localToWorldMatrix.GetPosition();
            combine[0].transform = NewMeshF.transform.localToWorldMatrix;





            Mesh NewMesh = new Mesh();
            NewMesh.CombineMeshes(combine);
            Destroy(pb.gameObject);
            //pb.gameObject.GetComponent<MeshFilter>().transform.position = pb.gameObject.GetComponent<MeshFilter>().transform.localToWorldMatrix.GetPosition() - Lev.localToWorldMatrix.GetPosition(); ;
            //Selection.objects = new Object[] { pb.gameObject };
            //pb.gameObject.GetComponent<Renderer>().material = Lev.GetComponent<Renderer>().material;
            //GetComponent<Renderer>().material
            return NewMesh;
        }
        public enum BooleanOp
        {
            Intersection,
            Union,
            Subtraction
        }

        const float k_DefaultEpsilon = 0.00001f;
        static float s_Epsilon = k_DefaultEpsilon;

        /// <summary>
        /// Tolerance used by <see cref="Plane.SplitPolygon"/> determine whether planes are coincident.
        /// </summary>
        public static float epsilon
        {
            get => s_Epsilon;
            set => s_Epsilon = value;
        }

        /// <summary>
        /// Performs a boolean operation on two GameObjects.
        /// </summary>
        /// <returns>A new mesh.</returns>

        /// <summary>
        /// Returns a new mesh by merging @lhs with @rhs.
        /// </summary>
        /// <param name="lhs">The base mesh of the boolean operation.</param>
        /// <param name="rhs">The input mesh of the boolean operation.</param>
        /// <returns>A new mesh if the operation succeeds, or null if an error occurs.</returns>
        /// 
        /// 
        /// 
        /// 
        /// <summary>
        /// Returns a new mesh by subtracting @lhs with @rhs.
        /// </summary>
        /// <param name="lhs">The base mesh of the boolean operation.</param>
        /// <param name="rhs">The input mesh of the boolean operation.</param>
        /// <returns>A new mesh if the operation succeeds, or null if an error occurs.</returns>

        /// <summary>
        /// Returns a new mesh by intersecting @lhs with @rhs.
        /// </summary>
        /// <param name="lhs">The base mesh of the boolean operation.</param>
        /// <param name="rhs">The input mesh of the boolean operation.</param>
        /// <returns>A new mesh if the operation succeeds, or null if an error occurs.</returns>
        //List<Polygon> polygons = Node.Intersect(a, b).AllPolygons();ehaviour

    }
}