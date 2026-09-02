using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;

// Token: 0x02002DFE RID: 11774
public class BulletEffectInfo
{
	// Token: 0x06017C79 RID: 97401 RVA: 0x006A0CF8 File Offset: 0x0069EEF8
	public void Clear()
	{
		if (Singleton<EffectSystem>.Instance.IsValid(this.EffectExtremity))
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.EffectExtremity, "[BulletEffectInfo.Clear]", true, null);
		}
		if (Singleton<EffectSystem>.Instance.IsValid(this.EffectBlock))
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.EffectBlock, "[BulletEffectInfo.Clear]", true, null);
		}
		this.EffectData = null;
		this.Effect = 0;
		this.EffectExtremity = 0;
		this.EffectBlock = 0;
		this.HandOver = false;
		this.IsFinishAuto = false;
		this.EffectOriginSize = 0f;
		this.IsEffectDestroy = false;
		this.DisablePostProcess = false;
	}

	// Token: 0x0400B7E1 RID: 47073
	[Nullable(2)]
	public BulletDataRender EffectData;

	// Token: 0x0400B7E2 RID: 47074
	public int Effect;

	// Token: 0x0400B7E3 RID: 47075
	public int EffectExtremity;

	// Token: 0x0400B7E4 RID: 47076
	public int EffectBlock;

	// Token: 0x0400B7E5 RID: 47077
	public bool HandOver;

	// Token: 0x0400B7E6 RID: 47078
	public bool IsFinishAuto;

	// Token: 0x0400B7E7 RID: 47079
	public float EffectOriginSize;

	// Token: 0x0400B7E8 RID: 47080
	public bool IsEffectDestroy;

	// Token: 0x0400B7E9 RID: 47081
	public bool DisablePostProcess;
}
