using UnityEngine;
using System.Collections;
using UnityEditor;

public class TestEditor : EditorWindow
{
    float secs = 10.0f;
    double startVal = 0;
    double progress = 0;
    bool isShow = false;

    [MenuItem("Examples/Cancelable Progress Bar Usage")]
    static void Init()
    {
        var window = GetWindow(typeof(TestEditor));
        window.Show();
    }

    void OnGUI()
    {
        secs = EditorGUILayout.FloatField("Time to wait:", secs);
        if (GUILayout.Button("Display bar"))
        {
            startVal = EditorApplication.timeSinceStartup; //��ʼ���뵽���ڵ�ʱ��  
            isShow = !isShow;
        }

        if (GUILayout.Button("Clear bar"))
        {
            EditorUtility.ClearProgressBar(); //��ս�������ֵ�� ����ûʲô��  
        }

        if (progress < secs && isShow == true)
        {
            //ʹ�������룬�ڽ�������߻���һ�� �رհ�ť����������仰��ֱ�ӿ������мǲ�Ҫ��  
            // EditorUtility.DisplayCancelableProgressBar("Simple Progress Bar", "Show a progress bar for the given seconds", (float)(progress / secs));  
            //ʹ����䴴��һ����������  ����1 Ϊ���⣬����2Ϊ��ʾ������3Ϊ ���Ȱٷֱ� 0~1 ֮��  
            EditorUtility.DisplayProgressBar("Simple Progress Bar", "Show a progress bar for the given seconds", (float)(progress / secs));
        }
        else
        {
            startVal = EditorApplication.timeSinceStartup;
            progress = 0.0f;
            return;
        }
        progress = EditorApplication.timeSinceStartup - startVal;
    }

    void OnInspectorUpdate() //����  
    {
        Repaint();  //���»���  
    }
}