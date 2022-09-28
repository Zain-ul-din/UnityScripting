using System;
using UnityEngine;
using UnityEditor;

namespace Randoms.Editor.Util
{  
    /// <summary>
    /// Unity GUILayout Styles
    /// </summary>
    [InitializeOnLoad]
    public static class GUIStyleUtil
    {
        /// <summary>
        /// Border color.
        /// </summary>
        public readonly static Color BorderColor;

        /// <summary>
        /// Box background color.
        /// </summary>
        public readonly static Color BoxBackgroundColor;

        /// <summary>
        /// Dark editor background color.
        /// </summary>
        public readonly static Color DarkEditorBackground;

        /// <summary>
        /// Editor window background color.
        /// </summary>
        public readonly static Color EditorWindowBackgroundColor;

        /// <summary>
        /// Menu background color.
        /// </summary>
        public readonly static Color MenuBackgroundColor;

        /// <summary>
        /// Header box background color.
        /// </summary>
        public readonly static Color HeaderBoxBackgroundColor;

        /// <summary>
        /// Highlighted Button Color.
        /// </summary>
        public readonly static Color HighlightedButtonColor;

        /// <summary>
        /// Highlight text color.
        /// </summary>
        public readonly static Color HighlightedTextColor;

        /// <summary>
        /// Highlight property color.
        /// </summary>
        public readonly static Color HighlightPropertyColor;

        /// <summary>
        /// List item color for every other item.
        /// </summary>
        public readonly static Color ListItemColorEven;

        /// <summary>
        /// List item hover color for every other item.
        /// </summary>
        public readonly static Color ListItemColorHoverEven;

        /// <summary>
        /// List item hover color for every other item.
        /// </summary>
        public readonly static Color ListItemColorHoverOdd;

        /// <summary>
        /// List item color for every other item.
        /// </summary>
        public readonly static Color ListItemColorOdd;

        /// <summary>
        /// List item drag background color.
        /// </summary>
        public readonly static Color ListItemDragBg;

        /// <summary>
        /// List item drag background color.
        /// </summary>
        public readonly static Color ListItemDragBgColor;

        /// <summary>
        /// Column title background colors.
        /// </summary>
        public readonly static Color ColumnTitleBg;

        /// <summary>
        /// List item background color for every other item.
        /// </summary>
        public readonly static Color ListItemEven;

        /// <summary>
        /// List item background color for every other item.
        /// </summary>
        public readonly static Color ListItemOdd;

        /// <summary>
        /// Menu button active background color.
        /// </summary>
        public readonly static Color MenuButtonActiveBgColor;

        /// <summary>
        /// Menu button border color.
        /// </summary>
        public readonly static Color MenuButtonBorderColor;

        /// <summary>
        /// Menu button color.
        /// </summary>
        public readonly static Color MenuButtonColor;

        /// <summary>
        /// Menu button hover color.
        /// </summary>
        public readonly static Color MenuButtonHoverColor;

        /// <summary>
        /// A light border color.
        /// </summary>
        public readonly static Color LightBorderColor;

        /// <summary>
        /// Bold label style.
        /// </summary>
        public static GUIStyle Temporary;

        private static GUIStyle boldLabel;

        private static GUIStyle boldLabelCentered;

        private static GUIStyle boxContainer;

        private static GUIStyle boxHeaderStyle;

        private static GUIStyle button;

        private static GUIStyle buttonSelected;

        private static GUIStyle buttonLeft;

        private static GUIStyle buttonLeftSelected;

        private static GUIStyle buttonMid;

        private static GUIStyle buttonMidSelected;

        private static GUIStyle buttonRight;

        private static GUIStyle buttonRightSelected;

        private static GUIStyle miniButton;

        private static GUIStyle colorFieldBackground;

        private static GUIStyle foldout;

        private static GUIStyle iconButton;

        private static GUIStyle label;

        private static GUIStyle labelCentered;

        private static GUIStyle leftAlignedGreyMiniLabel;

        private static GUIStyle leftAlignedWhiteMiniLabel;

        private static GUIStyle listItem;

        private static GUIStyle menuButtonBackground;

        private static GUIStyle none;

        private static GUIStyle paddingLessBox;

        private static GUIStyle contentPadding;

        private static GUIStyle propertyPadding;

        private static GUIStyle propertyMargin;

        private static GUIStyle richTextLabel;

        private static GUIStyle rightAlignedGreyMiniLabel;

        private static GUIStyle rightAlignedWhiteMiniLabel;

        private static GUIStyle sectionHeader;

        private static GUIStyle sectionHeaderCentered;

        private static GUIStyle toggleGroupBackground;

        private static GUIStyle toggleGroupCheckbox;

        private static GUIStyle toggleGroupPadding;

        private static GUIStyle toggleGroupTitleBg;

        private static GUIStyle toolbarBackground;

        private static GUIStyle toolbarButton;

        private static GUIStyle toolbarButtonSelected;

        private static GUIStyle toolbarSeachCancelButton;

        private static GUIStyle toolbarSeachTextField;

        private static GUIStyle toolbarTab;

        private static GUIStyle title;

        private static GUIStyle boldTitle;

        private static GUIStyle subtitle;

        private static GUIStyle titleRight;

        private static GUIStyle titleCentered;

        private static GUIStyle boldTitleRight;

        private static GUIStyle boldTitleCentered;

        private static GUIStyle subtitleCentered;

        private static GUIStyle subtitleRight;

        private static GUIStyle messageBox;

        private static GUIStyle detailedMessageBox;

        private static GUIStyle multiLineLabel;

        private static GUIStyle odinEditorWrapper;

        private static GUIStyle whiteLabel;

        private static GUIStyle blackLabel;

        private static GUIStyle miniButtonRightSelected;

        private static GUIStyle miniButtonRight;

        private static GUIStyle miniButtonLeftSelected;

        private static GUIStyle miniButtonLeft;

        private static GUIStyle miniButtonSelected;

        private static GUIStyle miniButtonMid;

        private static GUIStyle miniButtonMidSelected;

        private static GUIStyle centeredTextField;

        private static GUIStyle tagButton;

        private static GUIStyle centeredGreyMiniLabel;

        private static GUIStyle leftAlignedCenteredLabel;

        private static GUIStyle popup;

        private static GUIStyle multiLineCenteredLabel;

        private static GUIStyle dropDownMiniutton;

        private static GUIStyle bottomBoxPadding;

        private static GUIStyle paneOptions;

        private static GUIStyle containerOuterShadow;

        private static GUIStyle moduleHeader;

        private static GUIStyle containerOuterShadowGlow;

        private static GUIStyle cardStyle;

        private static GUIStyle centeredWhiteMiniLabel;

        private static GUIStyle centeredBlackMiniLabel;

        private static GUIStyle cardStyleMini;
        
        private static GUIStyle miniUtilButton;


        
        /// <summary>
        /// Black label style.
        /// </summary>
        public static GUIStyle BlackLabel
        {
            get
            {
                if (GUIStyleUtil.blackLabel == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(EditorStyles.label);
                    gUIStyle.margin = new RectOffset(0, 0, 0, 0);
                    GUIStyleUtil.blackLabel = gUIStyle;
                    GUIStyleUtil.blackLabel.normal.textColor = Color.black;
                    GUIStyleUtil.blackLabel.onNormal.textColor =  Color.black;
                }
                return GUIStyleUtil.blackLabel;
            }
        }

        /// <summary>
        /// Bold label style.
        /// </summary>
        public static GUIStyle BoldLabel
        {
            get
            {
                if (GUIStyleUtil.boldLabel == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(EditorStyles.boldLabel);
                    gUIStyle.contentOffset = new Vector2 (0f, 0f);
                    gUIStyle.margin = new RectOffset(0, 0, 0, 0);
                    GUIStyleUtil.boldLabel = gUIStyle;
                }
                return GUIStyleUtil.boldLabel;
            }
        }

        /// <summary>
        /// Centered bold label style.
        /// </summary>
        public static GUIStyle BoldLabelCentered
        {
            get
            {
                if (GUIStyleUtil.boldLabelCentered == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyleUtil.BoldLabel);
                    gUIStyle.alignment = TextAnchor.MiddleCenter;
                    GUIStyleUtil.boldLabelCentered = gUIStyle;
                }
                return GUIStyleUtil.boldLabelCentered;
            }
        }

        /// <summary>
        /// Bold title style.
        /// </summary>
        public static GUIStyle BoldTitle
        {
            get
            {
                if (GUIStyleUtil.boldTitle == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyleUtil.Title);
                    gUIStyle.fontStyle = FontStyle.Bold;
                    gUIStyle.padding = new RectOffset(0, 0, 0, 0);
                    GUIStyleUtil.boldTitle = gUIStyle;
                }
                return GUIStyleUtil.boldTitle;
            }
        }

        /// <summary>
        /// Centered bold title style.
        /// </summary>
        public static GUIStyle BoldTitleCentered
        {
            get
            {
                if (GUIStyleUtil.boldTitleCentered == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyleUtil.BoldTitle);
                    gUIStyle.alignment = TextAnchor.MiddleCenter;
                    GUIStyleUtil.boldTitleCentered = gUIStyle;
                }
                return GUIStyleUtil.boldTitleCentered;
            }
        }

        /// <summary>
        /// Right aligned bold title style.
        /// </summary>
        public static GUIStyle BoldTitleRight
        {
            get
            {
                if (GUIStyleUtil.boldTitleRight == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyleUtil.BoldTitle);
                    gUIStyle.alignment = TextAnchor.MiddleRight;
                    GUIStyleUtil.boldTitleRight = gUIStyle;
                }
                return GUIStyleUtil.boldTitleRight;
            }
        }

        /// <summary>
        /// Gets the bottom box padding.
        /// </summary>
        public static GUIStyle BottomBoxPadding
        {
            get
            {
                if (GUIStyleUtil.bottomBoxPadding == null)
                {
                    GUIStyle gUIStyle = new GUIStyle();
                    gUIStyle.padding = new RectOffset(0, 0, 3, 5);
                    gUIStyle.padding = new RectOffset(0, 0, 7, 0);
                    GUIStyleUtil.bottomBoxPadding = gUIStyle;
                }
                return GUIStyleUtil.bottomBoxPadding;
            }
        }

        /// <summary>
        /// Box container style.
        /// </summary>
        public static GUIStyle BoxContainer
        {
            get
            {
                if (GUIStyleUtil.boxContainer == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(EditorStyles.helpBox);
                    gUIStyle.margin = new RectOffset(0, 0, 0, 2);
                    GUIStyleUtil.boxContainer = gUIStyle;
                }
                return GUIStyleUtil.boxContainer;
            }
        }

        /// <summary>
        /// Box header style.
        /// </summary>
        public static GUIStyle BoxHeaderStyle
        {
            get
            {
                if (GUIStyleUtil.boxHeaderStyle == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyleUtil.None);
                    gUIStyle.margin = (new RectOffset(0, 0, 0, 2));
                    GUIStyleUtil.boxHeaderStyle = gUIStyle;
                }
                return GUIStyleUtil.boxHeaderStyle;
            }
        }

        /// <summary>
        /// Left button style.
        /// </summary>
        public static GUIStyle Button
        {
            get
            {
                if (GUIStyleUtil.button == null)
                {
                    GUIStyleUtil.button = new GUIStyle("Button");
                }
                return GUIStyleUtil.button;
            }
        }

        /// <summary>
        /// Left button style.
        /// </summary>
        public static GUIStyle ButtonLeft
        {
            get
            {
                if (GUIStyleUtil.buttonLeft == null)
                {
                    GUIStyleUtil.buttonLeft = new GUIStyle("ButtonLeft");
                }
                return GUIStyleUtil.buttonLeft;
            }
        }

        /// <summary>
        /// Left button selected style.
        /// </summary>
        public static GUIStyle ButtonLeftSelected
        {
            get
            {
                if (GUIStyleUtil.buttonLeftSelected == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyleUtil.ButtonLeft);
                    gUIStyle.normal = new GUIStyle(GUIStyleUtil.ButtonLeft).onNormal;
                    GUIStyleUtil.buttonLeftSelected = gUIStyle;
                }
                return GUIStyleUtil.buttonLeftSelected;
            }
        }

        /// <summary>
        /// Mid button style.
        /// </summary>
        public static GUIStyle ButtonMid
        {
            get
            {
                if (GUIStyleUtil.buttonMid == null)
                {
                    GUIStyleUtil.buttonMid = new GUIStyle("ButtonMid");
                }
                return GUIStyleUtil.buttonMid;
            }
        }

        /// <summary>
        /// Mid button selected style.
        /// </summary>
        public static GUIStyle ButtonMidSelected
        {
            get
            {
                if (GUIStyleUtil.buttonMidSelected == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyleUtil.ButtonMid);
                    gUIStyle.normal = new GUIStyle(GUIStyleUtil.ButtonMid).onNormal;
                    GUIStyleUtil.buttonMidSelected = gUIStyle;
                }
                return GUIStyleUtil.buttonMidSelected;
            }
        }

        /// <summary>
        /// Right button style.
        /// </summary>
        public static GUIStyle ButtonRight
        {
            get
            {
                if (GUIStyleUtil.buttonRight == null)
                {
                    GUIStyleUtil.buttonRight = new GUIStyle("ButtonRight");
                }
                return GUIStyleUtil.buttonRight;
            }
        }

        /// <summary>
        /// Right button selected style.
        /// </summary>
        public static GUIStyle ButtonRightSelected
        {
            get
            {
                if (GUIStyleUtil.buttonRightSelected == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyleUtil.ButtonRight);
                    gUIStyle.normal = new GUIStyle(GUIStyleUtil.ButtonRight).onNormal;
                    GUIStyleUtil.buttonRightSelected = gUIStyle;
                }
                return GUIStyleUtil.buttonRightSelected;
            }
        }

        /// <summary>
        /// Left button selected style.
        /// </summary>
        public static GUIStyle ButtonSelected
        {
            get
            {
                if (GUIStyleUtil.buttonSelected == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyleUtil.Button);
                    gUIStyle.normal = new GUIStyle(GUIStyleUtil.Button).onNormal;
                    GUIStyleUtil.buttonSelected = gUIStyle;
                }
                return GUIStyleUtil.buttonSelected;
            }
        }
        
        /// <summary>
        /// Mini Util Button
        /// </summary>
        public static GUIStyle MiniUtilButton
        {
            get 
            {
                if (miniUtilButton == null)
                {
                    GUIStyle gUIStyle = new GUIStyle (EditorStyles.miniButtonMid);
                    gUIStyle.padding = new RectOffset (1,1,1,1);
                    GUIStyleUtil.miniUtilButton = gUIStyle;
                }
                return GUIStyleUtil.miniUtilButton;
            }
        }

        /// <summary>
        /// Draw this one manually with: new Color(1, 1, 1, EditorGUIUtility.isProSkin ? 0.25f : 0.45f)
        /// </summary>
        public static GUIStyle CardStyle
        {
            get
            {
                if (GUIStyleUtil.cardStyle == null)
                {
                    GUIStyle gUIStyle = new GUIStyle("sv_iconselector_labelselection");
                    gUIStyle.padding = new RectOffset(15, 15, 15, 15);
                    gUIStyle.margin = new RectOffset(0, 0, 0, 0);
                    gUIStyle.stretchHeight = false;
                    GUIStyleUtil.cardStyle = gUIStyle;
                }
                return GUIStyleUtil.cardStyle;
            }
        }

        /// <summary>
        /// Centered black mini label style.
        /// </summary>
        public static GUIStyle CenteredBlackMiniLabel
        {
            get
            {
                if (GUIStyleUtil.centeredBlackMiniLabel == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(EditorStyles.centeredGreyMiniLabel);
                    gUIStyle.alignment = TextAnchor.MiddleCenter;
                    gUIStyle.clipping = TextClipping.Clip;
                    GUIStyleState gUIStyleState = new GUIStyleState();
                    gUIStyleState.textColor = Color.black;
                    gUIStyle.normal = gUIStyleState;
                    GUIStyleUtil.centeredBlackMiniLabel = gUIStyle;
                    #if UNITY_2019_3_OR_NEWER
                        GUIStyleUtil.centeredBlackMiniLabel.margin = new RectOffset(4, 4, 4, 4);
                    #endif
                }
                return GUIStyleUtil.centeredBlackMiniLabel;
            }
        }

        /// <summary>
        /// Centered grey mini label
        /// </summary>
        public static GUIStyle CenteredGreyMiniLabel
        {
            get
            {
                if (GUIStyleUtil.centeredGreyMiniLabel == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(EditorStyles.centeredGreyMiniLabel);
                    gUIStyle.alignment = TextAnchor.MiddleCenter;
                    gUIStyle.clipping = TextClipping.Clip;
                    GUIStyleUtil.centeredGreyMiniLabel = gUIStyle;
                    #if UNITY_2019_3_OR_NEWER
                     GUIStyleUtil.centeredGreyMiniLabel.margin = new RectOffset(4, 4, 4, 4);
                    #endif
                }
                return GUIStyleUtil.centeredGreyMiniLabel;
            }
        }

        /// <summary>
        /// Centered Text Field
        /// </summary>
        public static GUIStyle CenteredTextField
        {
            get
            {
                if (GUIStyleUtil.centeredTextField == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(EditorStyles.textField);
                    gUIStyle.alignment = TextAnchor.MiddleCenter;
                    GUIStyleUtil.centeredTextField = gUIStyle;
                }
                return GUIStyleUtil.centeredTextField;
            }
        }

        /// <summary>
        /// Centered white mini label style.
        /// </summary>
        public static GUIStyle CenteredWhiteMiniLabel
        {
            get
            {
                if (GUIStyleUtil.centeredWhiteMiniLabel == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(EditorStyles.centeredGreyMiniLabel);
                    gUIStyle.alignment = TextAnchor.MiddleCenter;
                    gUIStyle.clipping = TextClipping.Clip;
                    GUIStyleState gUIStyleState = new GUIStyleState();
                    gUIStyleState.textColor =  Color.white;
                    gUIStyle.normal = gUIStyleState;
                    GUIStyleUtil.centeredWhiteMiniLabel = gUIStyle;
                    #if UNITY_2019_3_OR_NEWER
                      GUIStyleUtil.centeredWhiteMiniLabel.margin = new RectOffset(4, 4, 4, 4);
                    #endif
                }
                return GUIStyleUtil.centeredWhiteMiniLabel;
            }
        }

        /// <summary>
        /// Color field background style.
        /// </summary>
        public static GUIStyle ColorFieldBackground
        {
            get
            {
                if (GUIStyleUtil.colorFieldBackground == null)
                {
                    GUIStyleUtil.colorFieldBackground = new GUIStyle("ShurikenEffectBg");
                }
                return GUIStyleUtil.colorFieldBackground;
            }
        }

        /// <summary>
        /// Unitys ProjectBrowserTextureIconDropShadow GUIStyle.
        /// </summary>
        public static GUIStyle ContainerOuterShadow
        {
            get
            {
                if (GUIStyleUtil.containerOuterShadow == null)
                {
                    GUIStyleUtil.containerOuterShadow = new GUIStyle("ProjectBrowserTextureIconDropShadow");
                }
                return GUIStyleUtil.containerOuterShadow;
            }
        }

        /// <summary>
        /// Unitys TL SelectionButton PreDropGlow GUIStyle.
        /// </summary>
        public static GUIStyle ContainerOuterShadowGlow
        {
            get
            {
                if (GUIStyleUtil.containerOuterShadowGlow == null)
                {
                    GUIStyleUtil.containerOuterShadowGlow = new GUIStyle("TL SelectionButton PreDropGlow");
                }
                return GUIStyleUtil.containerOuterShadowGlow;
            }
        }

        /// <summary>
        /// Content Padding
        /// </summary>
        public static GUIStyle ContentPadding
        {
            get
            {
                if (GUIStyleUtil.contentPadding == null)
                {
                    GUIStyle gUIStyle = new GUIStyle();
                    gUIStyle.padding = new RectOffset(3, 3, 3, 3);
                    GUIStyleUtil.contentPadding = gUIStyle;
                }
                return GUIStyleUtil.contentPadding;
            }
        }

        /// <summary>
        /// Detailed Message box style.
        /// </summary>
        public static GUIStyle DetailedMessageBox
        {
            get
            {
                if (GUIStyleUtil.detailedMessageBox == null)
                {
                    GUIStyleUtil.detailedMessageBox = new GUIStyle(GUIStyleUtil.MessageBox);
                    RectOffset _padding = GUIStyleUtil.detailedMessageBox.padding;
                    _padding.right = (int)(_padding.right + 18);
                }
                return GUIStyleUtil.detailedMessageBox;
            }
        }

        /// <summary>
        /// Pane Options Button
        /// </summary>
        public static GUIStyle DropDownMiniButton
        {
            get
            {
                if (GUIStyleUtil.dropDownMiniutton == null)
                {
                    GUIStyleUtil.dropDownMiniutton = new GUIStyle(EditorStyles.popup);
                }
                return GUIStyleUtil.dropDownMiniutton;
            }
        }

        /// <summary>
        /// Foldout style.
        /// </summary>
        public static GUIStyle Foldout
        {
            get
            {
                if (GUIStyleUtil.foldout == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(EditorStyles.foldout);
                    gUIStyle.fixedWidth = 0f;
                    gUIStyle.fixedHeight = 0f;
                    gUIStyle.stretchHeight = false;
                    gUIStyle.stretchWidth = true;
                    GUIStyleUtil.foldout = gUIStyle;
                    #if UNITY_2019_3_OR_NEWER
                        GUIStyle gUIStyle1 = GUIStyleUtil.foldout;
                        RectOffset rectOffset = new RectOffset();
                        rectOffset.left = GUIStyleUtil.foldout.margin.left;
                        rectOffset.right = GUIStyleUtil.foldout.margin.right;
                        rectOffset.top = 1;
                        rectOffset.bottom = 1;
                        gUIStyle1.margin = rectOffset;
                    #endif
                }
                return GUIStyleUtil.foldout;
            }
        }

        /// <summary>
        /// Icon button style.
        /// </summary>
        public static GUIStyle IconButton
        {
            get
            {
                if (GUIStyleUtil.iconButton == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyle.none);
                    gUIStyle.padding = new RectOffset(1, 1, 1, 1);
                    GUIStyleUtil.iconButton = gUIStyle;
                }
                return GUIStyleUtil.iconButton;
            }
        }

        /// <summary>
        /// Label style.
        /// </summary>
        public static GUIStyle Label
        {
            get
            {
                if (GUIStyleUtil.label == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(EditorStyles.label);
                    gUIStyle.margin = new RectOffset(0, 0, 0, 0);
                    GUIStyleUtil.label = gUIStyle;
                }
                return GUIStyleUtil.label;
            }
        }

        /// <summary>
        /// Centered label style.
        /// </summary>
        public static GUIStyle LabelCentered
        {
            get
            {
                if (GUIStyleUtil.labelCentered == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyleUtil.Label);
                    gUIStyle.alignment = TextAnchor.MiddleCenter;
                    gUIStyle.margin = new RectOffset(0, 0, 0, 0);
                    GUIStyleUtil.labelCentered = gUIStyle;
                }
                return GUIStyleUtil.labelCentered;
            }
        }

        /// <summary>
        /// Left Aligned Centered Label
        /// </summary>
        public static GUIStyle LeftAlignedCenteredLabel
        {
            get
            {
                if (GUIStyleUtil.leftAlignedCenteredLabel == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyleUtil.Label);
                    gUIStyle.alignment = TextAnchor.MiddleLeft;
                    gUIStyle.margin = new RectOffset(0, 0, 0, 0);
                    GUIStyleUtil.leftAlignedCenteredLabel = gUIStyle;
                }
                return GUIStyleUtil.leftAlignedCenteredLabel;
            }
        }

        /// <summary>
        /// Left aligned grey mini label style.
        /// </summary>
        public static GUIStyle LeftAlignedGreyMiniLabel
        {
            get
            {
                if (GUIStyleUtil.leftAlignedGreyMiniLabel == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(EditorStyles.centeredGreyMiniLabel);
                    gUIStyle.alignment = TextAnchor.MiddleLeft;
                    gUIStyle.clipping = TextClipping.Clip;
                    GUIStyleUtil.leftAlignedGreyMiniLabel = gUIStyle;
                    #if UNITY_2019_3_OR_NEWER
                        GUIStyleUtil.leftAlignedGreyMiniLabel.margin = new RectOffset(4, 4, 4, 4);
                    #endif
                }
                return GUIStyleUtil.leftAlignedGreyMiniLabel;
            }
        }

        /// <summary>
        /// Left right aligned white mini label style.
        /// </summary>
        public static GUIStyle LeftAlignedWhiteMiniLabel
        {
            get
            {
                if (GUIStyleUtil.leftAlignedWhiteMiniLabel == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(EditorStyles.centeredGreyMiniLabel);
                    gUIStyle.alignment = TextAnchor.MiddleLeft;
                    gUIStyle.clipping = TextClipping.Clip;
                    GUIStyleState gUIStyleState = new GUIStyleState();
                    gUIStyleState.textColor = Color.white;
                    gUIStyle.normal = gUIStyleState;
                    GUIStyleUtil.leftAlignedWhiteMiniLabel = gUIStyle;
                    #if UNITY_2019_3_OR_NEWER
                        GUIStyleUtil.leftAlignedWhiteMiniLabel.margin = new RectOffset(4, 4, 4, 4);
                    #endif
                }
                return GUIStyleUtil.leftAlignedWhiteMiniLabel;
            }
        }

        /// <summary>
        /// List item style.
        /// </summary>
        public static GUIStyle ListItem
        {
            get
            {
                if (GUIStyleUtil.listItem == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyleUtil.None);
                    gUIStyle.padding = new RectOffset(0, 0, 3, 3);
                    GUIStyleUtil.listItem = gUIStyle;
                }
                return GUIStyleUtil.listItem;
            }
        }

        /// <summary>
        /// Menu button background style.
        /// </summary>
        public static GUIStyle MenuButtonBackground
        {
            get
            {
                if (GUIStyleUtil.menuButtonBackground == null)
                {
                    GUIStyle gUIStyle = new GUIStyle();
                    gUIStyle.margin = new RectOffset(0, 1, 0, 0);
                    gUIStyle.padding = new RectOffset(0, 0, 4, 4);
                    gUIStyle.border = new RectOffset(0, 0, 0, 0);
                    GUIStyleUtil.menuButtonBackground = gUIStyle;
                }
                return GUIStyleUtil.menuButtonBackground;
            }
        }

        /// <summary>
        /// Message box style.
        /// </summary>
        public static GUIStyle MessageBox
        {
            get
            {
                if (GUIStyleUtil.messageBox == null)
                {
                    GUIStyle gUIStyle = new GUIStyle("HelpBox");
                    gUIStyle.margin = new RectOffset(4, 4, 2, 2);
                    gUIStyle.fontSize = 10;
                    gUIStyle.richText = true;
                    GUIStyleUtil.messageBox = gUIStyle;
                }
                return GUIStyleUtil.messageBox;
            }
        }

        /// <summary>
        /// Left button style.
        /// </summary>
        public static GUIStyle MiniButton
        {
            get
            {
                if (GUIStyleUtil.miniButton == null)
                {
                    GUIStyleUtil.miniButton = new GUIStyle(EditorStyles.miniButton);
                }
                return GUIStyleUtil.miniButton;
            }
        }

        /// <summary>
        /// Left button style.
        /// </summary>
        public static GUIStyle MiniButtonLeft
        {
            get
            {
                if (GUIStyleUtil.miniButtonLeft == null)
                {
                    GUIStyleUtil.miniButtonLeft = new GUIStyle(EditorStyles.miniButtonLeft);
                }
                return GUIStyleUtil.miniButtonLeft;
            }
        }

        /// <summary>
        /// Left button selected style.
        /// </summary>
        public static GUIStyle MiniButtonLeftSelected
        {
            get
            {
                if (GUIStyleUtil.miniButtonLeftSelected == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyleUtil.MiniButtonLeft);
                    gUIStyle.normal = new GUIStyle(GUIStyleUtil.MiniButtonLeft).onNormal;
                    GUIStyleUtil.miniButtonLeftSelected = gUIStyle;
                    #if UNITY_2019_3_OR_NEWER
                        GUIStyleUtil.miniButtonLeftSelected.normal.textColor =  GUIStyleUtil.HighlightedTextColor;
                    #endif
                }
                return GUIStyleUtil.miniButtonLeftSelected;
            }
        }

        /// <summary>
        /// Mid button style.
        /// </summary>
        public static GUIStyle MiniButtonMid
        {
            get
            {
                if (GUIStyleUtil.miniButtonMid == null)
                {
                    GUIStyleUtil.miniButtonMid = new GUIStyle(EditorStyles.miniButtonMid);
                }
                return GUIStyleUtil.miniButtonMid;
            }
        }

        /// <summary>
        /// Mid button selected style.
        /// </summary>
        public static GUIStyle MiniButtonMidSelected
        {
            get
            {
                if (GUIStyleUtil.miniButtonMidSelected == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyleUtil.MiniButtonMid);
                    gUIStyle.normal = new GUIStyle(GUIStyleUtil.MiniButtonMid).onNormal;
                    GUIStyleUtil.miniButtonMidSelected = gUIStyle;
                    #if UNITY_2019_3_OR_NEWER
                        GUIStyleUtil.miniButtonMidSelected.normal.textColor =  GUIStyleUtil.HighlightedTextColor;
                    #endif
                }
                return GUIStyleUtil.miniButtonMidSelected;
            }
        }

        /// <summary>
        /// Right button style.
        /// </summary>
        public static GUIStyle MiniButtonRight
        {
            get
            {
                if (GUIStyleUtil.miniButtonRight == null)
                {
                    GUIStyleUtil.miniButtonRight = new GUIStyle(EditorStyles.miniButtonRight);
                }
                return GUIStyleUtil.miniButtonRight;
            }
        }

        /// <summary>
        /// Right button selected style.
        /// </summary>
        public static GUIStyle MiniButtonRightSelected
        {
            get
            {
                if (GUIStyleUtil.miniButtonRightSelected == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyleUtil.MiniButtonRight);
                    gUIStyle.normal = new GUIStyle(GUIStyleUtil.MiniButtonRight).onNormal;
                    GUIStyleUtil.miniButtonRightSelected = gUIStyle;
                    #if UNITY_2019_3_OR_NEWER
                        GUIStyleUtil.miniButtonRightSelected.normal.textColor =  GUIStyleUtil.HighlightedTextColor ;
                    #endif
                }
                return GUIStyleUtil.miniButtonRightSelected;
            }
        }

        /// <summary>
        /// Left button selected style.
        /// </summary>
        public static GUIStyle MiniButtonSelected
        {
            get
            {
                if (GUIStyleUtil.miniButtonSelected == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyleUtil.MiniButton);
                    gUIStyle.normal = new GUIStyle(GUIStyleUtil.MiniButton).onNormal;
                    GUIStyleUtil.miniButtonSelected = gUIStyle;
                    #if UNITY_2019_3_OR_NEWER
                        GUIStyleUtil.miniButtonSelected.normal.textColor =  GUIStyleUtil.HighlightedTextColor ;
                    #endif
                }
                return GUIStyleUtil.miniButtonSelected;
            }
        }

        /// <summary>
        /// Unitys ShurikenModuleTitle GUIStyle.
        /// </summary>
        public static GUIStyle ModuleHeader
        {
            get
            {
                if (GUIStyleUtil.moduleHeader == null)
                {
                    GUIStyleUtil.moduleHeader = new GUIStyle("ShurikenModuleTitle");
                }
                return GUIStyleUtil.moduleHeader;
            }
        }

        /// <summary>
        /// Centered Multiline Label
        /// </summary>
        public static GUIStyle MultiLineCenteredLabel
        {
            get
            {
                if (GUIStyleUtil.multiLineCenteredLabel == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyleUtil.MultiLineLabel);
                    gUIStyle.stretchWidth = true;
                    gUIStyle.alignment = TextAnchor.MiddleCenter;
                    GUIStyleUtil.multiLineCenteredLabel = gUIStyle;
                }
                return GUIStyleUtil.multiLineCenteredLabel;
            }
        }

        /// <summary>
        /// Multiline Label
        /// </summary>
        public static GUIStyle MultiLineLabel
        {
            get
            {
                if (GUIStyleUtil.multiLineLabel == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(EditorStyles.label);
                    gUIStyle.richText = true;
                    gUIStyle.stretchWidth = false;
                    gUIStyle.wordWrap = true;
                    GUIStyleUtil.multiLineLabel = gUIStyle;
                }
                return GUIStyleUtil.multiLineLabel;
            }
        }

        /// <summary>
        /// No style.
        /// </summary>
        public static GUIStyle None
        {
            get
            {
                if (GUIStyleUtil.none == null)
                {
                    GUIStyle gUIStyle = new GUIStyle();
                    gUIStyle.margin = new RectOffset(0, 0, 0, 0);
                    gUIStyle.padding =new RectOffset(0, 0, 0, 0);
                    gUIStyle.border = new RectOffset(0, 0, 0, 0);
                    GUIStyleUtil.none = gUIStyle;
                }
                return GUIStyleUtil.none;
            }
        }

        /// <summary>
        /// Odin Editor Wrapper.
        /// </summary>
        public static GUIStyle OdinEditorWrapper
        {
            get
            {
                if (GUIStyleUtil.odinEditorWrapper == null)
                {
                    GUIStyle gUIStyle = new GUIStyle();
                    gUIStyle.padding = new RectOffset(4, 4, 0, 0);
                    GUIStyleUtil.odinEditorWrapper = gUIStyle;
                }
                return GUIStyleUtil.odinEditorWrapper;
            }
        }

        /// <summary>
        /// Padding less box style.
        /// </summary>
        public static GUIStyle PaddingLessBox
        {
            get
            {
                if (GUIStyleUtil.paddingLessBox == null)
                {
                    GUIStyle gUIStyle = new GUIStyle("box");
                    gUIStyle.padding = new RectOffset(1, 1, 0, 0);
                    GUIStyleUtil.paddingLessBox = gUIStyle;
                }
                return GUIStyleUtil.paddingLessBox;
            }
        }

        /// <summary>
        /// Unitys PaneOptions GUIStyle.
        /// </summary>
        public static GUIStyle PaneOptions
        {
            get
            {
                if (GUIStyleUtil.paneOptions == null)
                {
                    GUIStyleUtil.paneOptions = new GUIStyle("PaneOptions");
                }
                return GUIStyleUtil.paneOptions;
            }
        }

        /// <summary>
        /// Popup style.
        /// </summary>
        public static GUIStyle Popup
        {
            get
            {
                if (GUIStyleUtil.popup == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(EditorStyles.miniButton);
                    gUIStyle.alignment = TextAnchor.MiddleLeft;
                    GUIStyleUtil.popup = gUIStyle;
                }
                return GUIStyleUtil.popup;
            }
        }

        /// <summary>
        /// Property margin.
        /// </summary>
        public static GUIStyle PropertyMargin
        {
            get
            {
                if (GUIStyleUtil.propertyMargin == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyle.none);
                    gUIStyle.margin = new RectOffset(4, 0, 0, 0);
                    GUIStyleUtil.propertyMargin = gUIStyle;
                }
                return GUIStyleUtil.propertyMargin;
            }
        }

        /// <summary>
        /// Property padding.
        /// </summary>
        public static GUIStyle PropertyPadding
        {
            get
            {
                if (GUIStyleUtil.propertyPadding == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyle.none);
                    gUIStyle.padding = new RectOffset(0, 0, 0, 3);
                    gUIStyle.margin = new RectOffset(0, 0, 0, 0);
                    GUIStyleUtil.propertyPadding = gUIStyle;
                }
                return GUIStyleUtil.propertyPadding;
            }
        }

        /// <summary>
        /// Rich text label style.
        /// </summary>
        public static GUIStyle RichTextLabel
        {
            get
            {
                if (GUIStyleUtil.richTextLabel == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(EditorStyles.label);
                    gUIStyle.richText = true;
                    GUIStyleUtil.richTextLabel = gUIStyle;
                }
                return GUIStyleUtil.richTextLabel;
            }
        }

        /// <summary>
        /// Right aligned grey mini label style.
        /// </summary>
        public static GUIStyle RightAlignedGreyMiniLabel
        {
            get
            {
                if (GUIStyleUtil.rightAlignedGreyMiniLabel == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(EditorStyles.centeredGreyMiniLabel);
                    gUIStyle.alignment = TextAnchor.MiddleRight;
                    gUIStyle.clipping = TextClipping.Clip;
                    GUIStyleUtil.rightAlignedGreyMiniLabel = gUIStyle;
                    #if UNITY_2019_3_OR_NEWER
                        GUIStyleUtil.rightAlignedGreyMiniLabel.margin = new RectOffset(4, 4, 4, 4);
                    #endif
                }
                return GUIStyleUtil.rightAlignedGreyMiniLabel;
            }
        }

        /// <summary>
        /// Right aligned white mini label style.
        /// </summary>
        public static GUIStyle RightAlignedWhiteMiniLabel
        {
            get
            {
                if (GUIStyleUtil.rightAlignedWhiteMiniLabel == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(EditorStyles.centeredGreyMiniLabel);
                    gUIStyle.alignment = TextAnchor.MiddleRight;
                    gUIStyle.clipping = TextClipping.Clip;
                    GUIStyleState gUIStyleState = new GUIStyleState();
                    gUIStyleState.textColor = Color.white;
                    gUIStyle.normal = gUIStyleState;
                    GUIStyleUtil.rightAlignedWhiteMiniLabel = gUIStyle;
                    #if UNITY_2019_2_OR_NEWER
                        GUIStyleUtil.rightAlignedWhiteMiniLabel.margin = new RectOffset(4, 4, 4, 4);
                    #endif
                }
                return GUIStyleUtil.rightAlignedWhiteMiniLabel;
            }
        }

        /// <summary>
        /// Section header style.
        /// </summary>
        public static GUIStyle SectionHeader
        {
            get
            {
                if (GUIStyleUtil.sectionHeader == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(EditorStyles.largeLabel);
                    gUIStyle.fontSize = 22;
                    gUIStyle.margin = new RectOffset(0, 0, 5, 0);
                    gUIStyle.fontStyle = FontStyle.Bold;
                    gUIStyle.wordWrap = true;
                    gUIStyle.font = EditorStyles.centeredGreyMiniLabel.font;
                    gUIStyle.overflow = new RectOffset(0, 0, 0, 0);
                    GUIStyleUtil.sectionHeader = gUIStyle;
                }
                return GUIStyleUtil.sectionHeader;
            }
        }

        /// <summary>
        /// Section header style.
        /// </summary>
        public static GUIStyle SectionHeaderCentered
        {
            get
            {
                if (GUIStyleUtil.sectionHeaderCentered == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyleUtil.SectionHeader);
                    gUIStyle.alignment = TextAnchor.MiddleCenter;
                    GUIStyleUtil.sectionHeaderCentered = gUIStyle;
                }
                return GUIStyleUtil.sectionHeaderCentered;
            }
        }

        /// <summary>
        /// Subtitle style.
        /// </summary>
        public static GUIStyle Subtitle
        {
            get
            {
                if (GUIStyleUtil.subtitle == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyleUtil.Title);
                    gUIStyle.font = GUI.skin.button.font;
                    gUIStyle.fontSize = 10;
                    gUIStyle.contentOffset = new Vector2(0f, -3f);
                    gUIStyle.fixedHeight = 16f;
                    GUIStyleUtil.subtitle = gUIStyle;
                    Color _textColor =  GUIStyleUtil.subtitle.normal.textColor;
                    _textColor.a *= 0.7f;
                    GUIStyleUtil.subtitle.normal.textColor = _textColor;
                }
                return GUIStyleUtil.subtitle;
            }
        }

        /// <summary>
        /// Centered sub-title style.
        /// </summary>
        public static GUIStyle SubtitleCentered
        {
            get
            {
                if (GUIStyleUtil.subtitleCentered == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyleUtil.Subtitle);
                    gUIStyle.alignment = TextAnchor.MiddleRight;
                    GUIStyleUtil.subtitleCentered = gUIStyle;
                }
                return GUIStyleUtil.subtitleCentered;
            }
        }

        /// <summary>
        /// Right aligned sub-title style.
        /// </summary>
        public static GUIStyle SubtitleRight
        {
            get
            {
                if (GUIStyleUtil.subtitleRight == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyleUtil.Subtitle);
                    gUIStyle.alignment = TextAnchor.MiddleRight;
                    GUIStyleUtil.subtitleRight = gUIStyle;
                }
                return GUIStyleUtil.subtitleRight;
            }
        }

        /// <summary>
        /// Tag Button style.
        /// </summary>
        public static GUIStyle TagButton
        {
            get
            {
                if (GUIStyleUtil.tagButton == null)
                {
                    GUIStyle gUIStyle = new GUIStyle("MiniToolbarButton");
                    gUIStyle.alignment = TextAnchor.MiddleCenter;
                    gUIStyle.padding = new RectOffset();
                    gUIStyle.margin = new RectOffset();
                    gUIStyle.contentOffset = new Vector2(0f, 0f);
                    gUIStyle.fontSize = 9;
                    gUIStyle.font = EditorStyles.standardFont;
                    GUIStyleUtil.tagButton = gUIStyle;
                }
                return GUIStyleUtil.tagButton;
            }
        }

        /// <summary>
        /// Title style.
        /// </summary>
        public static GUIStyle Title
        {
            get
            {
                if (GUIStyleUtil.title == null)
                {
                    GUIStyleUtil.title = new GUIStyle(EditorStyles.label);
                }
                return GUIStyleUtil.title;
            }
        }

        /// <summary>
        /// Centered title style.
        /// </summary>
        public static GUIStyle TitleCentered
        {
            get
            {
                if (GUIStyleUtil.titleCentered == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyleUtil.Title);
                    gUIStyle.alignment = TextAnchor.MiddleCenter;
                    GUIStyleUtil.titleCentered = gUIStyle;
                }
                return GUIStyleUtil.titleCentered;
            }
        }

        /// <summary>
        /// Right aligned title style.
        /// </summary>
        public static GUIStyle TitleRight
        {
            get
            {
                if (GUIStyleUtil.titleRight == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyleUtil.Title);
                    gUIStyle.alignment = TextAnchor.MiddleRight;
                    GUIStyleUtil.titleRight = gUIStyle;
                }
                return GUIStyleUtil.titleRight;
            }
        }

        /// <summary>
        /// Toggle group background style.
        /// </summary>
        public static GUIStyle ToggleGroupBackground
        {
            get
            {
                if (GUIStyleUtil.toggleGroupBackground == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(EditorStyles.helpBox);
                    gUIStyle.overflow = new RectOffset(0, 0, 0, 0);
                    gUIStyle.margin = new RectOffset(0, 0, 0, 0);
                    gUIStyle.padding = new RectOffset(0, 0, 0, 0);
                    GUIStyleUtil.toggleGroupBackground = gUIStyle;
                }
                return GUIStyleUtil.toggleGroupBackground;
            }
        }

        /// <summary>
        /// Toggle group checkbox style.
        /// </summary>
        public static GUIStyle ToggleGroupCheckbox
        {
            get
            {
                if (GUIStyleUtil.toggleGroupCheckbox == null)
                {
                    GUIStyleUtil.toggleGroupCheckbox = new GUIStyle("ShurikenCheckMark");
                }
                return GUIStyleUtil.toggleGroupCheckbox;
            }
        }

        /// <summary>
        /// Toggle group padding style.
        /// </summary>
        public static GUIStyle ToggleGroupPadding
        {
            get
            {
                if (GUIStyleUtil.toggleGroupPadding == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyle.none);
                    gUIStyle.padding = new RectOffset(5, 5, 5, 5);
                    GUIStyleUtil.toggleGroupPadding = gUIStyle;
                }
                return GUIStyleUtil.toggleGroupPadding;
            }
        }

        /// <summary>
        /// Toggle group title background style.
        /// </summary>
        public static GUIStyle ToggleGroupTitleBg
        {
            get
            {
                if (GUIStyleUtil.toggleGroupTitleBg == null)
                {
                    GUIStyle gUIStyle = new GUIStyle("ShurikenModuleTitle");
                    gUIStyle.font = new GUIStyle("Label").font;
                    gUIStyle.border = new RectOffset(15, 7, 4, 4);
                    gUIStyle.fixedHeight = 22f;
                    gUIStyle.contentOffset = new Vector2(20f, -2f);
                    gUIStyle.margin = new RectOffset(0, 0, 3, 0);
                    GUIStyleUtil.toggleGroupTitleBg = gUIStyle;
                }
                return GUIStyleUtil.toggleGroupTitleBg;
            }
        }

        /// <summary>
        /// Toolbar background style.
        /// </summary>
        public static GUIStyle ToolbarBackground
        {
            get
            {
                if (GUIStyleUtil.toolbarBackground == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(EditorStyles.toolbar);
                    gUIStyle.padding = new RectOffset(0, 1, 0, 0);
                    gUIStyle.stretchHeight = true;
                    gUIStyle.stretchWidth = true;
                    gUIStyle.fixedHeight = 0f;
                    GUIStyleUtil.toolbarBackground = gUIStyle;
                    #if UNITY_2019_1_OR_NEWER
                        GUIStyleUtil.toolbarBackground.padding = new RectOffset(0, 0, 0, 0);
                    #endif
                }
                return GUIStyleUtil.toolbarBackground;
            }
            set
            {
                GUIStyleUtil.toolbarBackground = value;
            }
        }

        /// <summary>
        /// Toolbar button style.
        /// </summary>
        public static GUIStyle ToolbarButton
        {
            get
            {
                if (GUIStyleUtil.toolbarButton == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(EditorStyles.toolbarButton);
                    gUIStyle.fixedHeight = 0f;
                    gUIStyle.alignment = TextAnchor.MiddleCenter;
                    gUIStyle.stretchHeight = true;
                    gUIStyle.stretchWidth = false;
                    GUIStyleUtil.toolbarButton = gUIStyle;
                }
                return GUIStyleUtil.toolbarButton;
            }
        }

        /// <summary>
        /// Toolbar button selected style.
        /// </summary>
        public static GUIStyle ToolbarButtonSelected
        {
            get
            {
                if (GUIStyleUtil.toolbarButtonSelected == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(GUIStyleUtil.ToolbarButton);
                    gUIStyle.normal = new GUIStyle(GUIStyleUtil.ToolbarButton).onNormal;
                    GUIStyleUtil.toolbarButtonSelected = gUIStyle;
                }
                return GUIStyleUtil.toolbarButtonSelected;
            }
        }

        [Obsolete("Use ToolbarSearchCancelButton instead.")]
        public static GUIStyle ToolbarSeachCancelButton
        {
            get
            {
                return GUIStyleUtil.ToolbarSearchCancelButton;
            }
        }

        [Obsolete("Use ToolbarSearchTextField instead.")]
        public static GUIStyle ToolbarSeachTextField
        {
            get
            {
                return GUIStyleUtil.ToolbarSearchTextField;
            }
        }

        /// <summary>
        /// Toolbar search cancel button style.
        /// </summary>
        public static GUIStyle ToolbarSearchCancelButton
        {
            get
            {
                if (GUIStyleUtil.toolbarSeachCancelButton == null)
                {
                    GUIStyleUtil.toolbarSeachCancelButton = GUI.skin.FindStyle("ToolbarSeachCancelButton");
                }
                return GUIStyleUtil.toolbarSeachCancelButton;
            }
        }

        /// <summary>
        /// Toolbar search field style.
        /// </summary>
        public static GUIStyle ToolbarSearchTextField
        {
            get
            {
                if (GUIStyleUtil.toolbarSeachTextField == null)
                {
                    GUIStyleUtil.toolbarSeachTextField = GUI.skin.FindStyle("ToolbarSeachTextField");
                }
                return GUIStyleUtil.toolbarSeachTextField;
            }
        }

        /// <summary>
        /// Toolbar tab style.
        /// </summary>
        public static GUIStyle ToolbarTab
        {
            get
            {
                if (GUIStyleUtil.toolbarTab == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(EditorStyles.toolbarButton);
                    gUIStyle.fixedHeight = 0f;
                    gUIStyle.stretchHeight = true;
                    gUIStyle.stretchWidth = true;
                    GUIStyleUtil.toolbarTab = gUIStyle;
                }
                return GUIStyleUtil.toolbarTab;
            }
        }

        /// <summary>
        /// White label style.
        /// </summary>
        public static GUIStyle WhiteLabel
        {
            get
            {
                if (GUIStyleUtil.whiteLabel == null)
                {
                    GUIStyle gUIStyle = new GUIStyle(EditorStyles.label);
                    gUIStyle.margin = new RectOffset(0, 0, 0, 0);
                    GUIStyleUtil.whiteLabel = gUIStyle;
                    GUIStyleUtil.whiteLabel.normal.textColor = Color.white;
                    GUIStyleUtil.whiteLabel.onNormal.textColor = Color.white;
                }
                return GUIStyleUtil.whiteLabel;
            }
        }
        
        

        /// <summary>
        /// Draw this one manually with: new Color(1, 1, 1, EditorGUIUtility.isProSkin ? 0.25f : 0.45f)
        /// </summary>
        public static GUIStyle CardStyleMini
        {
            get
            {
                if (GUIStyleUtil.cardStyleMini == null)
                {
                    GUIStyle gUIStyle = new GUIStyle("sv_iconselector_labelselection");
                    gUIStyle.padding = new RectOffset(10, 10, 5, 5);
                    gUIStyle.margin = new RectOffset(0, 0, 0, 0);
                    gUIStyle.stretchHeight = false;
                    GUIStyleUtil.cardStyleMini = gUIStyle;
                }
                return GUIStyleUtil.cardStyleMini;
            }
        }

        static GUIStyleUtil()
        {
            GUIStyleUtil.BorderColor = (EditorGUIUtility.isProSkin ? new Color(0.11f, 0.11f, 0.11f, 0.8f) : new Color(0.38f, 0.38f, 0.38f, 0.6f));
            GUIStyleUtil.BoxBackgroundColor = (EditorGUIUtility.isProSkin ? new Color(1f, 1f, 1f, 0.05f) : new Color(1f, 1f, 1f, 0.5f));
            GUIStyleUtil.DarkEditorBackground = (EditorGUIUtility.isProSkin ? new Color(0.192f, 0.192f, 0.192f, 1f) : new Color(0f, 0f, 0f, 0f));
            GUIStyleUtil.EditorWindowBackgroundColor = (EditorGUIUtility.isProSkin ? new Color(0.22f, 0.22f, 0.22f, 1f) : new Color(0.76f, 0.76f, 0.76f, 1f));
            GUIStyleUtil.MenuBackgroundColor = (EditorGUIUtility.isProSkin ? new Color(1f, 1f, 1f, 0.035f) : new Color(0.87f, 0.87f, 0.87f, 1f));
            GUIStyleUtil.HeaderBoxBackgroundColor = (EditorGUIUtility.isProSkin ? new Color(1f, 1f, 1f, 0.06f) : new Color(1f, 1f, 1f, 0.26f));
            GUIStyleUtil.HighlightedButtonColor = (EditorGUIUtility.isProSkin ? new Color(0f, 1f, 0f, 1f) : new Color(0f, 1f, 0f, 1f));
            GUIStyleUtil.HighlightedTextColor =  (EditorGUIUtility.isProSkin ? new Color(1f, 1f, 1f, 1f) : new Color(0f, 0f, 0f, 1f));
            GUIStyleUtil.HighlightPropertyColor = (EditorGUIUtility.isProSkin ? new Color(1f, 1f, 1f, 0.6f) : new Color(0f, 0f, 0f, 0.6f));
            GUIStyleUtil.ListItemColorEven = (EditorGUIUtility.isProSkin ? new Color(0.235f, 0.235f, 0.235f, 1f) : new Color(0.838f, 0.838f, 0.838f, 1f));
            GUIStyleUtil.ListItemColorHoverEven = (EditorGUIUtility.isProSkin ? new Color(0.223200008f, 0.223200008f, 0.223200008f, 1f) : new Color(0.89f, 0.89f, 0.89f, 1f));
            GUIStyleUtil.ListItemColorHoverOdd = (EditorGUIUtility.isProSkin ? new Color(0.2472f, 0.2472f, 0.2472f, 1f) : new Color(0.904f, 0.904f, 0.904f, 1f));
            GUIStyleUtil.ListItemColorOdd = (EditorGUIUtility.isProSkin ? new Color(0.216f, 0.216f, 0.216f, 1f) : new Color(0.788f, 0.788f, 0.788f, 1f));
            GUIStyleUtil.ListItemDragBg = new Color(0.1f, 0.1f, 0.1f, 1f);
            GUIStyleUtil.ListItemDragBgColor = (EditorGUIUtility.isProSkin ? new Color(0.1f, 0.1f, 0.1f, 1f) : new Color(0.338f, 0.338f, 0.338f, 1f));
            GUIStyleUtil.ColumnTitleBg = (EditorGUIUtility.isProSkin ? new Color(1f, 1f, 1f, 0.019f) : new Color(1f, 1f, 1f, 0.019f));
            GUIStyleUtil.ListItemEven = new Color(0.4f, 0.4f, 0.4f, 1f);
            GUIStyleUtil.ListItemOdd = new Color(0.4f, 0.4f, 0.4f, 1f);
            GUIStyleUtil.MenuButtonActiveBgColor = (EditorGUIUtility.isProSkin ? new Color(0.243f, 0.373f, 0.588f, 1f) : new Color(0.243f, 0.49f, 0.9f, 1f));
            GUIStyleUtil.MenuButtonBorderColor = new Color(GUIStyleUtil.EditorWindowBackgroundColor.r * 0.8f, GUIStyleUtil.EditorWindowBackgroundColor.g * 0.8f, GUIStyleUtil.EditorWindowBackgroundColor.b * 0.8f);
            GUIStyleUtil.MenuButtonColor = new Color(0f, 0f, 0f, 0f);
            GUIStyleUtil.MenuButtonHoverColor = new Color(1f, 1f, 1f, 0.08f);
            GUIStyleUtil.LightBorderColor = new Color32(90, 90, 90, 255);
            GUIStyleUtil.Temporary = new GUIStyle();
        }
    } 
}