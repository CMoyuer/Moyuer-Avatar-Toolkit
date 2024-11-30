#if UNITY_EDITOR && VRC_SDK_VRCSDK3
using UnityEditor;
using UnityEngine;
using static VRChatAvatarToolkit.MoyuToolkitUtils;

namespace VRChatAvatarToolkit
{
    public class MoyuToolkit : EditorWindow
    {
        [MenuItem("VRC工具箱/VRC SDK 2转3", false, 1)]
        public static void ShowWindow()
        {
            GetWindow(typeof(FixAvatarToSdk3));
        }

        [MenuItem("VRC工具箱/快速穿戴", false, 50)]
        public static void ShowWindow_QuickDressed()
        {
            GetWindow(typeof(QuickDressed.QuickDressedEditor));
        }

        [MenuItem("VRC工具箱/动作播放器", false, 51)]
        public static void ShowWindow_AvatarAnimationPlayer()
        {
            GetWindow(typeof(AvatarAnimationPlayer.AvatarAnimationPlayerEditor));
        }

        [MenuItem("VRC工具箱/我的衣柜", false, 52)]
        public static void ShowWindow_AvatarWardrobe()
        {
            GetWindow(typeof(AvatarWardrobe));
        }

        [MenuItem("VRC工具箱/动作管理器", false, 53)]
        static void ShowWindow_ActionManager()
        {
            GetWindow(typeof(ActionManager));
        }

        [MenuItem("VRC工具箱/MMD动作转换", false, 100)]
        public static void ShowWindow_Vmd2Anim()
        {
            GetWindow(typeof(Vmd2Anim));
        }

        [MenuItem("VRC工具箱/Language/Reload I18N", false, 1)]
        public static void Reload_I18N()
        {
            I18N.Instance.Reload();
        }

        // 其他
        [MenuItem("VRC工具箱/By: 如梦/视频教程", false, 1000)]
        static void ShowWindow_GotoVideo()
        {
            Application.OpenURL("https://www.bilibili.com/video/BV13q4y1f7ZJ");
        }

        [MenuItem("VRC工具箱/By: 如梦/图文教程", false, 1001)]
        static void ShowWindow_GotoGiteeReadme()
        {
            Application.OpenURL("https://gitee.com/cmoyuer/vrchat-avatar-toolkit/blob/master/README.md");
        }

        [MenuItem("VRC工具箱/By: 如梦/开源仓库", false, 1002)]
        static void ShowWindow_GotoGitee()
        {
            Application.OpenURL("https://gitee.com/cmoyuer/vrchat-avatar-toolkit");
        }

        [MenuItem("VRC工具箱/By: 如梦/检查更新", false, 1003)]
        static void ShowWindow_GotoGiteeReleases()
        {
            Application.OpenURL("https://gitee.com/cmoyuer/vrchat-avatar-toolkit/releases/");
        }

        [MenuItem("VRC工具箱/By: 如梦/更多插件", false, 1004)]
        static void ShowWindow_GotoAfdian()
        {
            Application.OpenURL("https://afdian.net/@moyuer?tab=feed");
        }

        // Override Method
        private static new void GetWindow(System.Type t)
        {
            _ = I18N.Instance;
            EditorWindow.GetWindow(t);
        }
    }
}
#endif