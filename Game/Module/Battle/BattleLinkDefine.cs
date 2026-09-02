using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F2D RID: 24365
	[NullableContext(1)]
	[Nullable(0)]
	public static class BattleLinkDefine
	{
		// Token: 0x0402250F RID: 140559
		public const string BATTLE_LINK_BP_PATH = "/Game/Aki/Sequence/Common_Seq/Video/SplitScreen/BP_SplitScreen.BP_SplitScreen_C";

		// Token: 0x04022510 RID: 140560
		public const string BATTLE_LINK_BP_NEW_PATH = "/Game/Aki/Sequence/Common_Seq/Video/SplitScreen/BP_SplitScreen_New.BP_SplitScreen_New_C";

		// Token: 0x04022511 RID: 140561
		public const string THREE_ROLE_SEQ_PATH = "/Game/Aki/Character/SequenceCamera/Connet_Skill_Seq/SC3_Connect_Skill.SC3_Connect_Skill";

		// Token: 0x04022512 RID: 140562
		public const string THREE_ROLE_SEQ_NEW_PATH = "/Game/Aki/Character/SequenceCamera/Connet_Skill_Seq/NewLink/SC3_Connect_Skill_New.SC3_Connect_Skill_New";

		// Token: 0x04022513 RID: 140563
		public const string TWO_ROLE_SEQ_PATH = "/Game/Aki/Character/SequenceCamera/Connet_Skill_Seq/SC2_Connect_Skill.SC2_Connect_Skill";

		// Token: 0x04022514 RID: 140564
		public const string TWO_ROLE_SEQ_NEW_PATH = "/Game/Aki/Character/SequenceCamera/Connet_Skill_Seq/NewLink/SC2_Connect_Skill_New.SC2_Connect_Skill_New";

		// Token: 0x04022515 RID: 140565
		public const string EXPLOSION_EFFECT_PATH = "/Game/Aki/Effect/DataAsset/PostProcess/BigWorld/DA_Fx_Post_Link.DA_Fx_Post_Link";

		// Token: 0x04022516 RID: 140566
		public const string SKILL_BUTTON_EFFECT_PATH = "/Game/Aki/Effect/UI/Niagaras/Common/NS_Fx_LGUI_Fight_Link.NS_Fx_LGUI_Fight_Link";

		// Token: 0x04022517 RID: 140567
		public const float LINK_POST_EFFECT_DURATION = 0.3f;

		// Token: 0x04022518 RID: 140568
		public const float LINK_TRIGGER_INTERVAL = 200f;

		// Token: 0x04022519 RID: 140569
		public const int LINK_BURST_POST_EFFECT = 10010093;

		// Token: 0x0402251A RID: 140570
		public const string ZHEZHI_WEAPON_MESH = "/Game/Aki/Character/Weapon/Prop/Role/ZhezhiProp/EZhezhiMaobixiaoMd10011/Model/EZhezhiMaobixiaoMd10011.EZhezhiMaobixiaoMd10011";

		// Token: 0x0402251B RID: 140571
		public const string ZHEZHI_WEAPON_ANIM = "/Game/Aki/Character/Weapon/Prop/Role/ZhezhiProp/EZhezhiMaobixiaoMd10011/BaseAnim/Maobi_CosPose.Maobi_CosPose";
	}
}
