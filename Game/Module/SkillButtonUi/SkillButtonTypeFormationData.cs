using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.SkillButtonUi
{
	// Token: 0x02004F87 RID: 20359
	public class SkillButtonTypeFormationData
	{
		// Token: 0x060348D2 RID: 215250 RVA: 0x00D2C0CC File Offset: 0x00D2A2CC
		public void Clear()
		{
			this.SkillIconPath = null;
			this.EnableSkillId = 0;
			this.IsLongPressControlCamera = false;
			this.LongPressTime = 0;
			this.IgnoreHiddenTag = false;
			this.IgnoreDefaultHidden = false;
			this.ExtraEffect = ESkillButtonExtraEffect.None;
			this.ExtraEffectDuration = 0f;
		}

		// Token: 0x0401E484 RID: 124036
		[Nullable(2)]
		public string SkillIconPath;

		// Token: 0x0401E485 RID: 124037
		public int EnableSkillId;

		// Token: 0x0401E486 RID: 124038
		public bool IsLongPressControlCamera;

		// Token: 0x0401E487 RID: 124039
		public int LongPressTime;

		// Token: 0x0401E488 RID: 124040
		public bool IgnoreHiddenTag;

		// Token: 0x0401E489 RID: 124041
		public bool IgnoreDefaultHidden;

		// Token: 0x0401E48A RID: 124042
		public ESkillButtonExtraEffect ExtraEffect;

		// Token: 0x0401E48B RID: 124043
		public float ExtraEffectDuration;
	}
}
