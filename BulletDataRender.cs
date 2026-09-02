using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;

// Token: 0x02002DA5 RID: 11685
[NullableContext(1)]
[Nullable(0)]
public class BulletDataRender
{
	// Token: 0x17001F7A RID: 8058
	// (get) Token: 0x0601796C RID: 96620 RVA: 0x0068FAA9 File Offset: 0x0068DCA9
	public FName VictimCameraShakeOnHit
	{
		get
		{
			if (this.VictimCameraShakeOnHitInternal == null)
			{
				this.VictimCameraShakeOnHitInternal = new FName?(this.Data.命中时受击者震屏.GetAssetPathName());
			}
			return this.VictimCameraShakeOnHitInternal.Value;
		}
	}

	// Token: 0x17001F7B RID: 8059
	// (get) Token: 0x0601796D RID: 96621 RVA: 0x0068FADE File Offset: 0x0068DCDE
	public FName AttackerCameraShakeOnHit
	{
		get
		{
			if (this.AttackerCameraShakeOnHitInternal == null)
			{
				this.AttackerCameraShakeOnHitInternal = new FName?(this.Data.命中时攻击者震屏.GetAssetPathName());
			}
			return this.AttackerCameraShakeOnHitInternal.Value;
		}
	}

	// Token: 0x17001F7C RID: 8060
	// (get) Token: 0x0601796E RID: 96622 RVA: 0x0068FB14 File Offset: 0x0068DD14
	public Dictionary<EBulletHitEffect, FName> EffectOnHit
	{
		get
		{
			if (this.EffectOnHitInternal == null)
			{
				this.EffectOnHitInternal = new Dictionary<EBulletHitEffect, FName>();
				foreach (KeyValuePair<TEnumAsByte<EBulletHitEffect>, TSoftObjectPtr<UObject>> keyValuePair in this.Data.命中特效DA)
				{
					TEnumAsByte<EBulletHitEffect> tenumAsByte;
					TSoftObjectPtr<UObject> tsoftObjectPtr;
					keyValuePair.Deconstruct(out tenumAsByte, out tsoftObjectPtr);
					TEnumAsByte<EBulletHitEffect> value = tenumAsByte;
					TSoftObjectPtr<UObject> tsoftObjectPtr2 = tsoftObjectPtr;
					this.EffectOnHitInternal.Add(value, tsoftObjectPtr2.GetAssetPathName());
				}
			}
			return this.EffectOnHitInternal;
		}
	}

	// Token: 0x17001F7D RID: 8061
	// (get) Token: 0x0601796F RID: 96623 RVA: 0x0068FBA0 File Offset: 0x0068DDA0
	public string AudioOnHit
	{
		get
		{
			if (this.AudioOnHitInternal == null)
			{
				this.AudioOnHitInternal = this.Data.命中音效;
			}
			return this.AudioOnHitInternal;
		}
	}

	// Token: 0x17001F7E RID: 8062
	// (get) Token: 0x06017970 RID: 96624 RVA: 0x0068FBC4 File Offset: 0x0068DDC4
	public Dictionary<global::EBulletEffectOnHitType, BulletHitEffectConf> EffectOnHitConf
	{
		get
		{
			if (this.EffectOnHitConfInternal == null)
			{
				this.EffectOnHitConfInternal = new Dictionary<global::EBulletEffectOnHitType, BulletHitEffectConf>();
				TArray<SBulletEffectOnHitConf> 命中特效配置 = this.Data.命中特效配置;
				int num = 命中特效配置.Num();
				for (int i = 0; i < num; i++)
				{
					SBulletEffectOnHitConf sbulletEffectOnHitConf = 命中特效配置.Get(i);
					BulletHitEffectConf value = new BulletHitEffectConf(sbulletEffectOnHitConf);
					this.EffectOnHitConfInternal.Add((global::EBulletEffectOnHitType)sbulletEffectOnHitConf.类型, value);
				}
			}
			return this.EffectOnHitConfInternal;
		}
	}

	// Token: 0x17001F7F RID: 8063
	// (get) Token: 0x06017971 RID: 96625 RVA: 0x0068FC31 File Offset: 0x0068DE31
	public FName EffectBullet
	{
		get
		{
			if (this.EffectBulletInternal == null)
			{
				this.EffectBulletInternal = new FName?(this.Data.子弹特效DA.GetAssetPathName());
			}
			return this.EffectBulletInternal.Value;
		}
	}

	// Token: 0x17001F80 RID: 8064
	// (get) Token: 0x06017972 RID: 96626 RVA: 0x0068FC68 File Offset: 0x0068DE68
	public Dictionary<int, string> EffectBulletParams
	{
		get
		{
			if (this.EffectBulletParamsInternal == null)
			{
				this.EffectBulletParamsInternal = new Dictionary<int, string>();
				foreach (KeyValuePair<TEnumAsByte<AkiClient.Game.Aki.Core.Fight.EBulletEffectParam>, string> keyValuePair in this.Data.子弹特效DA参数)
				{
					TEnumAsByte<AkiClient.Game.Aki.Core.Fight.EBulletEffectParam> tenumAsByte;
					string text;
					keyValuePair.Deconstruct(out tenumAsByte, out text);
					TEnumAsByte<AkiClient.Game.Aki.Core.Fight.EBulletEffectParam> value = tenumAsByte;
					string value2 = text;
					this.EffectBulletParamsInternal.Add((int)value, value2);
				}
			}
			return this.EffectBulletParamsInternal;
		}
	}

	// Token: 0x17001F81 RID: 8065
	// (get) Token: 0x06017973 RID: 96627 RVA: 0x0068FCF0 File Offset: 0x0068DEF0
	public bool EffectStopInsteadDestroy
	{
		get
		{
			if (this.EffectStopInsteadDestroyInternal == null)
			{
				this.EffectStopInsteadDestroyInternal = new bool?(this.Data.子弹销毁调用子弹停止特效);
			}
			return this.EffectStopInsteadDestroyInternal.Value;
		}
	}

	// Token: 0x17001F82 RID: 8066
	// (get) Token: 0x06017974 RID: 96628 RVA: 0x0068FD20 File Offset: 0x0068DF20
	public bool HandOverParentEffect
	{
		get
		{
			if (this.HandOverParentEffectInternal == null)
			{
				this.HandOverParentEffectInternal = new bool?(this.Data.接手父子弹的特效);
			}
			return this.HandOverParentEffectInternal.Value;
		}
	}

	// Token: 0x17001F83 RID: 8067
	// (get) Token: 0x06017975 RID: 96629 RVA: 0x0068FD50 File Offset: 0x0068DF50
	public int CameraShakeCountMax
	{
		get
		{
			if (this.CameraShakeCountMaxInternal == null)
			{
				this.CameraShakeCountMaxInternal = new int?(this.Data.最大震动次数);
			}
			return this.CameraShakeCountMaxInternal.Value;
		}
	}

	// Token: 0x17001F84 RID: 8068
	// (get) Token: 0x06017976 RID: 96630 RVA: 0x0068FD80 File Offset: 0x0068DF80
	public Dictionary<EBulletSpecificEffect, FName> SpecialEffect
	{
		get
		{
			if (this.SpecialEffectInternal == null)
			{
				this.SpecialEffectInternal = new Dictionary<EBulletSpecificEffect, FName>();
				foreach (KeyValuePair<TEnumAsByte<EBulletSpecificEffect>, TSoftObjectPtr<UObject>> keyValuePair in this.Data.特殊特效DA)
				{
					TEnumAsByte<EBulletSpecificEffect> tenumAsByte;
					TSoftObjectPtr<UObject> tsoftObjectPtr;
					keyValuePair.Deconstruct(out tenumAsByte, out tsoftObjectPtr);
					TEnumAsByte<EBulletSpecificEffect> value = tenumAsByte;
					TSoftObjectPtr<UObject> tsoftObjectPtr2 = tsoftObjectPtr;
					this.SpecialEffectInternal.Add(value, tsoftObjectPtr2.GetAssetPathName());
				}
			}
			return this.SpecialEffectInternal;
		}
	}

	// Token: 0x17001F85 RID: 8069
	// (get) Token: 0x06017977 RID: 96631 RVA: 0x0068FE0C File Offset: 0x0068E00C
	public FName AttackerCameraShakeOnStart
	{
		get
		{
			if (this.AttackerCameraShakeOnStartInternal == null)
			{
				this.AttackerCameraShakeOnStartInternal = new FName?(this.Data.生成时攻击者震屏.GetAssetPathName());
			}
			return this.AttackerCameraShakeOnStartInternal.Value;
		}
	}

	// Token: 0x17001F86 RID: 8070
	// (get) Token: 0x06017978 RID: 96632 RVA: 0x0068FE41 File Offset: 0x0068E041
	public bool CameraShakeToSummonOwner
	{
		get
		{
			if (this.CameraShakeToSummonOwnerInternal == null)
			{
				this.CameraShakeToSummonOwnerInternal = new bool?(this.Data.震屏关联到召唤兽主人);
			}
			return this.CameraShakeToSummonOwnerInternal.Value;
		}
	}

	// Token: 0x17001F87 RID: 8071
	// (get) Token: 0x06017979 RID: 96633 RVA: 0x0068FE71 File Offset: 0x0068E071
	public FName AttackerCameraShakeOnHitWeakPoint
	{
		get
		{
			if (this.AttackerCameraShakeOnHitWeakPointInternal == null)
			{
				this.AttackerCameraShakeOnHitWeakPointInternal = new FName?(this.Data.命中弱点时攻击者震屏.GetAssetPathName());
			}
			return this.AttackerCameraShakeOnHitWeakPointInternal.Value;
		}
	}

	// Token: 0x17001F88 RID: 8072
	// (get) Token: 0x0601797A RID: 96634 RVA: 0x0068FEA6 File Offset: 0x0068E0A6
	public FName OnHitMaterialEffect
	{
		get
		{
			if (this.OnHitMaterialEffectInternal == null)
			{
				this.OnHitMaterialEffectInternal = new FName?(this.Data.受击闪白.GetAssetPathName());
			}
			return this.OnHitMaterialEffectInternal.Value;
		}
	}

	// Token: 0x0601797B RID: 96635 RVA: 0x0068FEDB File Offset: 0x0068E0DB
	public BulletDataRender(SReBulletDataPerformance data)
	{
		this.Data = data;
	}

	// Token: 0x0601797C RID: 96636 RVA: 0x0068FEEA File Offset: 0x0068E0EA
	public bool Preload()
	{
		FName effectBullet = this.EffectBullet;
		bool handOverParentEffect = this.HandOverParentEffect;
		int cameraShakeCountMax = this.CameraShakeCountMax;
		Dictionary<EBulletSpecificEffect, FName> specialEffect = this.SpecialEffect;
		FName attackerCameraShakeOnStart = this.AttackerCameraShakeOnStart;
		string audioOnHit = this.AudioOnHit;
		return (bool)true;
	}

	// Token: 0x0400B548 RID: 46408
	[Nullable(2)]
	private readonly SReBulletDataPerformance Data;

	// Token: 0x0400B549 RID: 46409
	private FName? VictimCameraShakeOnHitInternal;

	// Token: 0x0400B54A RID: 46410
	private FName? AttackerCameraShakeOnHitInternal;

	// Token: 0x0400B54B RID: 46411
	[Nullable(2)]
	private Dictionary<EBulletHitEffect, FName> EffectOnHitInternal;

	// Token: 0x0400B54C RID: 46412
	[Nullable(2)]
	private string AudioOnHitInternal;

	// Token: 0x0400B54D RID: 46413
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<global::EBulletEffectOnHitType, BulletHitEffectConf> EffectOnHitConfInternal;

	// Token: 0x0400B54E RID: 46414
	private FName? EffectBulletInternal;

	// Token: 0x0400B54F RID: 46415
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, string> EffectBulletParamsInternal;

	// Token: 0x0400B550 RID: 46416
	private bool? EffectStopInsteadDestroyInternal;

	// Token: 0x0400B551 RID: 46417
	private bool? HandOverParentEffectInternal;

	// Token: 0x0400B552 RID: 46418
	private int? CameraShakeCountMaxInternal;

	// Token: 0x0400B553 RID: 46419
	[Nullable(2)]
	private Dictionary<EBulletSpecificEffect, FName> SpecialEffectInternal;

	// Token: 0x0400B554 RID: 46420
	private FName? AttackerCameraShakeOnStartInternal;

	// Token: 0x0400B555 RID: 46421
	private bool? CameraShakeToSummonOwnerInternal;

	// Token: 0x0400B556 RID: 46422
	private FName? AttackerCameraShakeOnHitWeakPointInternal;

	// Token: 0x0400B557 RID: 46423
	private FName? OnHitMaterialEffectInternal;
}
