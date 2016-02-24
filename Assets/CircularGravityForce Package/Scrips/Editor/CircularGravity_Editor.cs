/*******************************************************************************************
* Author: Lane Gresham, AKA LaneMax
* Websites: http://resurgamstudios.com
* Version: 3.10
* Created Date: 11-27-14
* Last Updated: 08-23-15
* Description: Used overwriting the Inspector GUI, and Scene GUI
*******************************************************************************************/
using UnityEditor;
using UnityEngine;
using System;
using System.Collections;
using CircularGravityForce;

[CustomEditor(typeof(CircularGravity)), CanEditMultipleObjects]
public class CircularGravity_Editor : Editor
{
    private SerializedProperty enable_property;
    private SerializedProperty shape_property;
    private SerializedProperty forceType_property;
    private SerializedProperty forceMode_property;
    private SerializedProperty forcePower_property;
    private SerializedProperty size_property;
    private SerializedProperty torqueMaxAngularVelocity_property;
    private SerializedProperty explosionForceUpwardsModifier_property;
    private SerializedProperty capsuleRadius_property;
    private SerializedProperty toggleFilterOptions_property;

    private CircularGravity cgf;

    private bool change = false;
    private float spacing = 10f;
    private float midWidth = 50f;

    public void OnEnable()
    {
        enable_property = serializedObject.FindProperty("enable");
        shape_property = serializedObject.FindProperty("shape");
        forceType_property = serializedObject.FindProperty("forceType");
        forceMode_property = serializedObject.FindProperty("forceMode");
        forcePower_property = serializedObject.FindProperty("forcePower");
        size_property = serializedObject.FindProperty("size");
        torqueMaxAngularVelocity_property = serializedObject.FindProperty("forceTypeProperties.torqueMaxAngularVelocity");
        explosionForceUpwardsModifier_property = serializedObject.FindProperty("forceTypeProperties.explosionForceUpwardsModifier");
        capsuleRadius_property = serializedObject.FindProperty("capsuleRadius");
        toggleFilterOptions_property = serializedObject.FindProperty("toggleFilterOptions");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        /*<Enable----------------------------------------------------------------------------------------------------------*/
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(enable_property, new GUIContent("Enable"), GUILayout.MinWidth(midWidth));
        if (EditorGUI.EndChangeCheck())
        {
            enable_property.boolValue = EditorGUILayout.Toggle(enable_property.boolValue);
            change = true;
        }
        /*----------------------------------------------------------------------------------------------------------Enable>*/

        /*<Shape-----------------------------------------------------------------------------------------------------------*/
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(shape_property, new GUIContent("Shape"), GUILayout.MinWidth(midWidth));
        if (EditorGUI.EndChangeCheck())
        {
            shape_property.enumValueIndex = Convert.ToInt32(EditorGUILayout.EnumPopup((CircularGravity.Shape)shape_property.enumValueIndex));
            change = true;
        }
        /*-----------------------------------------------------------------------------------------------------------Shape>*/

        /*<Force Type------------------------------------------------------------------------------------------------------*/
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(forceType_property, new GUIContent("Force Type"), GUILayout.MinWidth(midWidth));
        if (EditorGUI.EndChangeCheck())
        {
            forceType_property.enumValueIndex = Convert.ToInt32(EditorGUILayout.EnumPopup((CircularGravity.ForceType)forceType_property.enumValueIndex));
            change = true;
        }
        /*------------------------------------------------------------------------------------------------------Force Type>*/

        /*<Force Mode------------------------------------------------------------------------------------------------------*/
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(forceMode_property, new GUIContent("Force Mode"), GUILayout.MinWidth(midWidth));
        if (EditorGUI.EndChangeCheck())
        {
            forceMode_property.enumValueIndex = Convert.ToInt32(EditorGUILayout.EnumPopup((ForceMode)forceMode_property.enumValueIndex));
            change = true;
        }
        /*------------------------------------------------------------------------------------------------------Force Mode>*/

        /*<Force Power-----------------------------------------------------------------------------------------------------*/
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(forcePower_property, new GUIContent("Force Power"), GUILayout.MinWidth(midWidth));
        if (EditorGUI.EndChangeCheck())
        {
            forcePower_property.floatValue = EditorGUILayout.FloatField(forcePower_property.floatValue);
            change = true;
        }
        /*-----------------------------------------------------------------------------------------------------Force Power>*/

        switch (forceType_property.enumValueIndex)
        {
            case (int)CircularGravity.ForceType.Torque:

                /*<Max Angular Velocity--------------------------------------------------------------------------------------------*/
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(torqueMaxAngularVelocity_property, new GUIContent("Max Angular Velocity"), GUILayout.MinWidth(midWidth));
                if (EditorGUI.EndChangeCheck())
                {
                    torqueMaxAngularVelocity_property.floatValue = EditorGUILayout.FloatField(torqueMaxAngularVelocity_property.floatValue);
                    change = true;
                }
                /*--------------------------------------------------------------------------------------------Max Angular Velocity>*/

                break;

            case (int)CircularGravity.ForceType.ExplosionForce:

                /*<Upwards Modifier------------------------------------------------------------------------------------------------*/
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(explosionForceUpwardsModifier_property, new GUIContent("Upwards Modifier"), GUILayout.MinWidth(midWidth));
                if (EditorGUI.EndChangeCheck())
                {
                    explosionForceUpwardsModifier_property.floatValue = EditorGUILayout.FloatField(explosionForceUpwardsModifier_property.floatValue);
                    change = true;
                }
                /*------------------------------------------------------------------------------------------------Upwards Modifier>*/

                break;
        }

        /*<Size------------------------------------------------------------------------------------------------------------*/
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(size_property, new GUIContent("Size"), GUILayout.MinWidth(midWidth));
        if (EditorGUI.EndChangeCheck())
        {
            if (size_property.floatValue >= 0)
            {
                size_property.floatValue = EditorGUILayout.FloatField(size_property.floatValue);
            }
            else
            {
                size_property.floatValue = 0;
            }
        }
        /*------------------------------------------------------------------------------------------------------------Size>*/

        switch (shape_property.enumValueIndex)
        {
            case (int)CircularGravity.Shape.Capsule:

                /*<Capsule Radius--------------------------------------------------------------------------------------------------*/
                EditorGUI.BeginChangeCheck();
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(capsuleRadius_property, new GUIContent("Capsule Radius"), GUILayout.MinWidth(midWidth));
                if (EditorGUI.EndChangeCheck())
                {
                    if (capsuleRadius_property.floatValue >= 0)
                    {
                        capsuleRadius_property.floatValue = EditorGUILayout.FloatField(capsuleRadius_property.floatValue);
                    }
                    else
                    {
                        capsuleRadius_property.floatValue = 0;
                    }

                    change = true;
                }
                /*--------------------------------------------------------------------------------------------------Capsule Radius>*/

                break;
        }

        /*<constraintProperties--------------------------------------------------------------------------------------------*/
        EditorGUIUtility.LookLikeControls();
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("constraintProperties"), true, GUILayout.ExpandWidth(true));
        if (EditorGUI.EndChangeCheck())
            serializedObject.ApplyModifiedProperties();
        EditorGUIUtility.LookLikeControls();
        /*--------------------------------------------------------------------------------------------constraintProperties>*/

        toggleFilterOptions_property.boolValue = EditorGUILayout.Foldout(toggleFilterOptions_property.boolValue, "Filter Options");
        if (toggleFilterOptions_property.boolValue)
        {
            /*<gameobjectFilter------------------------------------------------------------------------------------------------*/
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("", GUILayout.Width(spacing));
            EditorGUIUtility.LookLikeControls();
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("gameobjectFilter"), true, GUILayout.ExpandWidth(true));
            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();
            EditorGUIUtility.LookLikeControls();
            GUILayout.EndHorizontal();
            /*------------------------------------------------------------------------------------------------gameobjectFilter>*/

            /*<tagFilter-------------------------------------------------------------------------------------------------------*/
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("", GUILayout.Width(spacing));
            EditorGUIUtility.LookLikeControls();
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("tagFilter"), true, GUILayout.ExpandWidth(true));
            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();
            EditorGUIUtility.LookLikeControls();
            GUILayout.EndHorizontal();
            /*-------------------------------------------------------------------------------------------------------tagFilter>*/

            /*<layerFilter-----------------------------------------------------------------------------------------------------*/
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("", GUILayout.Width(spacing));
            EditorGUIUtility.LookLikeControls();
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("layerFilter"), true, GUILayout.ExpandWidth(true));
            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();
            EditorGUIUtility.LookLikeControls();
            GUILayout.EndHorizontal();
            /*-----------------------------------------------------------------------------------------------------layerFilter>*/

            /*<triggerAreaFilter-----------------------------------------------------------------------------------------------*/
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("", GUILayout.Width(spacing));
            EditorGUIUtility.LookLikeControls();
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("triggerAreaFilter"), true, GUILayout.ExpandWidth(true));
            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();
            EditorGUIUtility.LookLikeControls();
            GUILayout.EndHorizontal();
            /*-----------------------------------------------------------------------------------------------triggerAreaFilter>*/
        }

        /*<specialEffect---------------------------------------------------------------------------------------------------*/
        EditorGUIUtility.LookLikeControls();
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("specialEffect"), true, GUILayout.ExpandWidth(true));
        if (EditorGUI.EndChangeCheck())
            serializedObject.ApplyModifiedProperties();
        EditorGUIUtility.LookLikeControls();
        /*---------------------------------------------------------------------------------------------------specialEffect>*/

        /*<drawGravityProperties-------------------------------------------------------------------------------------------*/
        EditorGUIUtility.LookLikeControls();
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("drawGravityProperties"), true, GUILayout.ExpandWidth(true));
        if (EditorGUI.EndChangeCheck())
            serializedObject.ApplyModifiedProperties();
        EditorGUIUtility.LookLikeControls();
        /*-------------------------------------------------------------------------------------------drawGravityProperties>*/

        if (change)
        {
            change = false;
            toggleFilterOptions_property.boolValue = false;
        }

        serializedObject.ApplyModifiedProperties();
    }

    void OnSceneGUI()
    {
        cgf = (CircularGravity)target;

        Color mainColor;
        Color tranMainColor;

        if (cgf.Enable)
        {
            if (cgf.ForcePower == 0)
            {
                mainColor = Color.white;
                tranMainColor = Color.white;
            }
            else if (cgf.ForcePower > 0)
            {
                mainColor = Color.green;
                tranMainColor = Color.green;
            }
            else
            {
                mainColor = Color.red;
                tranMainColor = Color.red;
            }
        }
        else
        {
            mainColor = Color.white;
            tranMainColor = Color.white;
        }

        tranMainColor.a = .1f;

        Handles.color = mainColor;

        float gizmoSize = 0f;
        float gizmoOffset = 0f;

        if (mainColor == Color.green)
        {
            gizmoSize = (cgf.Size / 8f);
            if (gizmoSize > .5f)
                gizmoSize = .5f;
            else if (gizmoSize < -.5f)
                gizmoSize = -.5f;
            gizmoOffset = -gizmoSize / 2f;
        }
        else if (mainColor == Color.red)
        {
            gizmoSize = -(cgf.Size / 8f);
            if (gizmoSize > .5f)
                gizmoSize = .5f;
            else if (gizmoSize < -.5f)
                gizmoSize = -.5f;
            gizmoOffset = gizmoSize / 2f;
        }

        Quaternion qUp = cgf.transform.transform.rotation;
        qUp.SetLookRotation(cgf.transform.rotation * Vector3.up);
        Quaternion qDown = cgf.transform.transform.rotation;
        qDown.SetLookRotation(cgf.transform.rotation * Vector3.down);
        Quaternion qLeft = cgf.transform.transform.rotation;
        qLeft.SetLookRotation(cgf.transform.rotation * Vector3.left);
        Quaternion qRight = cgf.transform.transform.rotation;
        qRight.SetLookRotation(cgf.transform.rotation * Vector3.right);
        Quaternion qForward = cgf.transform.transform.rotation;
        qForward.SetLookRotation(cgf.transform.rotation * Vector3.forward);
        Quaternion qBack = cgf.transform.transform.rotation;
        qBack.SetLookRotation(cgf.transform.rotation * Vector3.back);

        float dotSpace = 10f;

        switch (cgf._shape)
        {
            case CircularGravity.Shape.Sphere:

                Handles.color = tranMainColor;
                Handles.SphereCap(0, cgf.transform.position, cgf.transform.rotation, cgf.Size * 2f);
                Handles.color = mainColor;

                if (cgf._forceType == CircularGravity.ForceType.ExplosionForce || cgf._forceType == CircularGravity.ForceType.ForceAtPosition || cgf._forceType == CircularGravity.ForceType.GravitationalAttraction)
                {
                    Handles.DrawDottedLine(GetVector(Vector3.up, cgf.Size, 1), cgf.transform.position, dotSpace);
                    Handles.DrawDottedLine(GetVector(Vector3.down, cgf.Size, 1), cgf.transform.position, dotSpace);
                    Handles.DrawDottedLine(GetVector(Vector3.left, cgf.Size, 1), cgf.transform.position, dotSpace);
                    Handles.DrawDottedLine(GetVector(Vector3.right, cgf.Size, 1), cgf.transform.position, dotSpace);

                    Handles.ConeCap(0, GetVector(Vector3.up, cgf.Size + gizmoOffset, 1f), qUp, gizmoSize);
                    Handles.ConeCap(0, GetVector(Vector3.down, cgf.Size + gizmoOffset, 1f), qDown, gizmoSize);
                    Handles.ConeCap(0, GetVector(Vector3.left, cgf.Size + gizmoOffset, 1f), qLeft, gizmoSize);
                    Handles.ConeCap(0, GetVector(Vector3.right, cgf.Size + gizmoOffset, 1f), qRight, gizmoSize);
                    Handles.ConeCap(0, GetVector(Vector3.back, cgf.Size + gizmoOffset, 1f), qBack, gizmoSize);

                    Handles.CircleCap(0, cgf.transform.position, qUp, cgf.Size);
                    Handles.CircleCap(0, cgf.transform.position, qForward, cgf.Size);
                }
                else if (cgf._forceType == CircularGravity.ForceType.Torque)
                {
                    Handles.DrawDottedLine(GetVector(Vector3.up, cgf.Size, 1), cgf.transform.position, dotSpace);
                    Handles.DrawDottedLine(GetVector(Vector3.down, cgf.Size, 1), cgf.transform.position, dotSpace);

                    Handles.ConeCap(0, GetVector(Vector3.up, cgf.Size + gizmoOffset, 1f), qForward, gizmoSize);
                    Handles.ConeCap(0, GetVector(Vector3.down, cgf.Size + gizmoOffset, 1f), qBack, gizmoSize);
                    Handles.ConeCap(0, GetVector(Vector3.forward, cgf.Size + gizmoOffset, 1f), qDown, gizmoSize);
                    Handles.ConeCap(0, GetVector(Vector3.back, cgf.Size + gizmoOffset, 1f), qUp, gizmoSize);

                }
                else
                {
                    Handles.ConeCap(0, GetVector(Vector3.back, cgf.Size + gizmoOffset, 1f), qBack, -gizmoSize);
                }

                Handles.DrawDottedLine(GetVector(Vector3.forward, cgf.Size, 1), cgf.transform.position, dotSpace);
                Handles.DrawDottedLine(GetVector(Vector3.back, cgf.Size, 1), cgf.transform.position, dotSpace);

                if (cgf._forceType != CircularGravity.ForceType.Torque)
                {
                    Handles.ConeCap(0, GetVector(Vector3.forward, cgf.Size + gizmoOffset, 1f), qForward, gizmoSize);
                }

                Handles.CircleCap(0, cgf.transform.position, qLeft, cgf.Size);

                break;
            case CircularGravity.Shape.Capsule:

                Handles.DrawDottedLine(GetVector(Vector3.up, cgf.CapsuleRadius, 1), cgf.transform.position, dotSpace);
                Handles.DrawDottedLine(GetVector(Vector3.down, cgf.CapsuleRadius, 1), cgf.transform.position, dotSpace);
                Handles.DrawDottedLine(GetVector(Vector3.left, cgf.CapsuleRadius, 1), cgf.transform.position, dotSpace);
                Handles.DrawDottedLine(GetVector(Vector3.right, cgf.CapsuleRadius, 1), cgf.transform.position, dotSpace);

                Handles.DrawDottedLine(cgf.transform.position, GetVector(Vector3.forward, cgf.Size, 1), dotSpace);

                Handles.DrawDottedLine(GetVector(Vector3.forward, cgf.Size, 1) + ((cgf.transform.rotation * Vector3.up) * cgf.CapsuleRadius), GetVector(Vector3.forward, cgf.Size, 1), dotSpace);
                Handles.DrawDottedLine(GetVector(Vector3.forward, cgf.Size, 1) + ((cgf.transform.rotation * Vector3.down) * cgf.CapsuleRadius), GetVector(Vector3.forward, cgf.Size, 1), dotSpace);
                Handles.DrawDottedLine(GetVector(Vector3.forward, cgf.Size, 1) + ((cgf.transform.rotation * Vector3.left) * cgf.CapsuleRadius), GetVector(Vector3.forward, cgf.Size, 1), dotSpace);
                Handles.DrawDottedLine(GetVector(Vector3.forward, cgf.Size, 1) + ((cgf.transform.rotation * Vector3.right) * cgf.CapsuleRadius), GetVector(Vector3.forward, cgf.Size, 1), dotSpace);

                if (cgf._forceType != CircularGravity.ForceType.Torque)
                {
                    Handles.ConeCap(0, GetVector(Vector3.forward, cgf.Size + gizmoOffset, 1f), qForward, gizmoSize);
                }
                else
                {
                    Handles.ConeCap(0, GetVector(Vector3.forward, cgf.Size + gizmoOffset, 1f), qDown, gizmoSize);
                }

                Handles.CircleCap(0, cgf.transform.position, qForward, cgf.CapsuleRadius);
                Handles.CircleCap(0, GetVector(Vector3.forward, cgf.Size, 1), qForward, cgf.CapsuleRadius);

                break;
            case CircularGravity.Shape.RayCast:

                Handles.DrawDottedLine(cgf.transform.position + ((cgf.transform.rotation * Vector3.forward) * cgf.Size), cgf.transform.position, dotSpace);

                if (cgf._forceType != CircularGravity.ForceType.Torque)
                {
                    Handles.ConeCap(0, GetVector(Vector3.forward, cgf.Size + gizmoOffset, 1f), qForward, gizmoSize);
                }
                else
                {
                    Handles.ConeCap(0, GetVector(Vector3.forward, cgf.Size + gizmoOffset, 1f), qDown, gizmoSize);
                }

                break;
        }

        if (cgf._forceType == CircularGravity.ForceType.ExplosionForce || cgf._forceType == CircularGravity.ForceType.ForceAtPosition || cgf._forceType == CircularGravity.ForceType.GravitationalAttraction)
        {
            Handles.SphereCap(0, cgf.transform.position, cgf.transform.rotation, gizmoSize/2f);
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }

    Vector3 GetVector(Vector3 vector, float size, float times)
    {
        return cgf.transform.position + (((cgf.transform.rotation * vector) * size) / times);
    }
}
