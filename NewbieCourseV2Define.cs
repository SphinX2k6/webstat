using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200144E RID: 5198
[NullableContext(1)]
[Nullable(0)]
public class NewbieCourseV2Define : IStaticVariableResetter
{
	// Token: 0x060090C3 RID: 37059 RVA: 0x00260F10 File Offset: 0x0025F110
	static NewbieCourseV2Define()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(NewbieCourseV2Define.CreateStaticDefaultValue), new Action(NewbieCourseV2Define.ResetStaticDefaultValue));
	}

	// Token: 0x060090C4 RID: 37060 RVA: 0x00260F30 File Offset: 0x0025F130
	public static void CreateStaticDefaultValue()
	{
		NewbieCourseV2Define.LevelPrefixSpriteIds = new Dictionary<ENewbieCourseV2ItemState, string>
		{
			{
				ENewbieCourseV2ItemState.Unaccomplished,
				"SP_SynesthesiaLvBlue"
			},
			{
				ENewbieCourseV2ItemState.CanReceive,
				"SP_SynesthesiaLvGold"
			},
			{
				ENewbieCourseV2ItemState.HasReceived,
				"SP_SynesthesiaLvPurple"
			}
		};
		NewbieCourseV2Define.BackgroundTextureIds = new Dictionary<ENewbieCourseV2ItemState, string>
		{
			{
				ENewbieCourseV2ItemState.Unaccomplished,
				"T_TogSynesthesiaANor"
			},
			{
				ENewbieCourseV2ItemState.CanReceive,
				"T_TogSynesthesiaCNor"
			},
			{
				ENewbieCourseV2ItemState.HasReceived,
				"T_TogSynesthesiaBNor"
			}
		};
		NewbieCourseV2Define.BackgroundHoldTextureIds = new Dictionary<ENewbieCourseV2ItemState, string>
		{
			{
				ENewbieCourseV2ItemState.Unaccomplished,
				"T_TogSynesthesiaAHold"
			},
			{
				ENewbieCourseV2ItemState.CanReceive,
				"T_TogSynesthesiaCHold"
			},
			{
				ENewbieCourseV2ItemState.HasReceived,
				"T_TogSynesthesiaBHold"
			}
		};
		NewbieCourseV2Define.LeftDigitMaterialIds = new Dictionary<ENewbieCourseV2ItemState, string>
		{
			{
				ENewbieCourseV2ItemState.Unaccomplished,
				"MI_TextureClipAlphaLockL"
			},
			{
				ENewbieCourseV2ItemState.CanReceive,
				"MI_TextureClipAlphaRewardL"
			},
			{
				ENewbieCourseV2ItemState.HasReceived,
				"MI_TextureClipAlphaDoneL"
			}
		};
		NewbieCourseV2Define.RightDigitMaterialIds = new Dictionary<ENewbieCourseV2ItemState, string>
		{
			{
				ENewbieCourseV2ItemState.Unaccomplished,
				"MI_TextureClipAlphaLockR"
			},
			{
				ENewbieCourseV2ItemState.CanReceive,
				"MI_TextureClipAlphaRewardR"
			},
			{
				ENewbieCourseV2ItemState.HasReceived,
				"MI_TextureClipAlphaDoneR"
			}
		};
	}

	// Token: 0x060090C5 RID: 37061 RVA: 0x00261023 File Offset: 0x0025F223
	public static void ResetStaticDefaultValue()
	{
		NewbieCourseV2Define.LevelPrefixSpriteIds = null;
		NewbieCourseV2Define.BackgroundTextureIds = null;
		NewbieCourseV2Define.BackgroundHoldTextureIds = null;
		NewbieCourseV2Define.LeftDigitMaterialIds = null;
		NewbieCourseV2Define.RightDigitMaterialIds = null;
	}

	// Token: 0x04004328 RID: 17192
	public const float RewardListContentTopPadding = 16f;

	// Token: 0x04004329 RID: 17193
	public static Dictionary<ENewbieCourseV2ItemState, string> LevelPrefixSpriteIds;

	// Token: 0x0400432A RID: 17194
	public static Dictionary<ENewbieCourseV2ItemState, string> BackgroundTextureIds;

	// Token: 0x0400432B RID: 17195
	public static Dictionary<ENewbieCourseV2ItemState, string> BackgroundHoldTextureIds;

	// Token: 0x0400432C RID: 17196
	public static Dictionary<ENewbieCourseV2ItemState, string> LeftDigitMaterialIds;

	// Token: 0x0400432D RID: 17197
	public static Dictionary<ENewbieCourseV2ItemState, string> RightDigitMaterialIds;
}
