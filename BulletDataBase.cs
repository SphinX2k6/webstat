using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;

// Token: 0x02002D9D RID: 11677
[NullableContext(1)]
[Nullable(0)]
public class BulletDataBase
{
	// Token: 0x17001F07 RID: 7943
	// (get) Token: 0x060178DF RID: 96479 RVA: 0x0068D756 File Offset: 0x0068B956
	public bool IgnoreGradient
	{
		get
		{
			if (this.IgnoreGradientInternal == null)
			{
				this.IgnoreGradientInternal = new bool?(this.Data.不适配坡度);
			}
			return this.IgnoreGradientInternal.Value;
		}
	}

	// Token: 0x17001F08 RID: 7944
	// (get) Token: 0x060178E0 RID: 96480 RVA: 0x0068D786 File Offset: 0x0068B986
	public Vector CenterOffset
	{
		get
		{
			if (this.CenterOffsetInternal == null)
			{
				this.CenterOffsetInternal = Vector.Create(this.Data.中心位置偏移);
			}
			return this.CenterOffsetInternal;
		}
	}

	// Token: 0x17001F09 RID: 7945
	// (get) Token: 0x060178E1 RID: 96481 RVA: 0x0068D7B1 File Offset: 0x0068B9B1
	public long DamageId
	{
		get
		{
			if (this.DamageIdInternal == null)
			{
				this.DamageIdInternal = new long?(this.Data.伤害ID);
			}
			return this.DamageIdInternal.Value;
		}
	}

	// Token: 0x17001F0A RID: 7946
	// (get) Token: 0x060178E2 RID: 96482 RVA: 0x0068D7E4 File Offset: 0x0068B9E4
	[Nullable(2)]
	public long[] MultiDamageId
	{
		[NullableContext(2)]
		get
		{
			if (!this.InitedMultiDamageId)
			{
				this.InitedMultiDamageId = true;
				TArray<long> 多伤害ID = this.Data.多伤害ID;
				int num = 多伤害ID.Num();
				if (num > 0)
				{
					this.MultiDamageIdInternal = new long[num];
					for (int i = 0; i < num; i++)
					{
						this.MultiDamageIdInternal[i] = 多伤害ID.Get(i);
					}
				}
			}
			return this.MultiDamageIdInternal;
		}
	}

	// Token: 0x17001F0B RID: 7947
	// (get) Token: 0x060178E3 RID: 96483 RVA: 0x0068D844 File Offset: 0x0068BA44
	public bool EnablePartHitAudio
	{
		get
		{
			if (this.EnablePartHitAudioInternal == null)
			{
				this.EnablePartHitAudioInternal = new bool?(this.Data.是否响应材质受击音效);
			}
			return this.EnablePartHitAudioInternal.Value;
		}
	}

	// Token: 0x17001F0C RID: 7948
	// (get) Token: 0x060178E4 RID: 96484 RVA: 0x0068D874 File Offset: 0x0068BA74
	public bool IntervalAfterHit
	{
		get
		{
			if (this.IntervalAfterHitInternal == null)
			{
				this.IntervalAfterHitInternal = new bool?(this.Data.作用间隔基于个体);
			}
			return this.IntervalAfterHitInternal.Value;
		}
	}

	// Token: 0x17001F0D RID: 7949
	// (get) Token: 0x060178E5 RID: 96485 RVA: 0x0068D8A4 File Offset: 0x0068BAA4
	public float Interval
	{
		get
		{
			if (this.IntervalInternal == null)
			{
				this.IntervalInternal = new float?(this.Data.作用间隔);
			}
			return this.IntervalInternal.Value;
		}
	}

	// Token: 0x17001F0E RID: 7950
	// (get) Token: 0x060178E6 RID: 96486 RVA: 0x0068D8D4 File Offset: 0x0068BAD4
	public bool ShareCounter
	{
		get
		{
			if (this.ShareCounterInternal == null)
			{
				this.ShareCounterInternal = new bool?(this.Data.共享父子弹次数);
			}
			return this.ShareCounterInternal.Value;
		}
	}

	// Token: 0x17001F0F RID: 7951
	// (get) Token: 0x060178E7 RID: 96487 RVA: 0x0068D904 File Offset: 0x0068BB04
	public Vector BornPosition
	{
		get
		{
			if (this.BornPositionInternal == null)
			{
				this.BornPositionInternal = Vector.Create(this.Data.出生位置偏移);
			}
			return this.BornPositionInternal;
		}
	}

	// Token: 0x17001F10 RID: 7952
	// (get) Token: 0x060178E8 RID: 96488 RVA: 0x0068D92F File Offset: 0x0068BB2F
	public EPositionStandard BornPositionStandard
	{
		get
		{
			if (this.BornPositionStandardInternal == null)
			{
				this.BornPositionStandardInternal = new EPositionStandard?((EPositionStandard)this.Data.出生位置基准);
			}
			return this.BornPositionStandardInternal.Value;
		}
	}

	// Token: 0x17001F11 RID: 7953
	// (get) Token: 0x060178E9 RID: 96489 RVA: 0x0068D964 File Offset: 0x0068BB64
	public Vector BornPositionRandom
	{
		get
		{
			if (this.BornPositionRandomInternal == null)
			{
				this.BornPositionRandomInternal = Vector.Create(this.Data.出生位置随机);
			}
			return this.BornPositionRandomInternal;
		}
	}

	// Token: 0x17001F12 RID: 7954
	// (get) Token: 0x060178EA RID: 96490 RVA: 0x0068D98F File Offset: 0x0068BB8F
	public Vector Size
	{
		get
		{
			if (this.SizeInternal == null)
			{
				this.SizeInternal = Vector.Create(this.Data.初始大小);
			}
			return this.SizeInternal;
		}
	}

	// Token: 0x17001F13 RID: 7955
	// (get) Token: 0x060178EB RID: 96491 RVA: 0x0068D9BA File Offset: 0x0068BBBA
	public Rotator Rotator
	{
		get
		{
			if (this.RotatorInternal == null)
			{
				this.RotatorInternal = Rotator.Create(this.Data.初始旋转);
			}
			return this.RotatorInternal;
		}
	}

	// Token: 0x17001F14 RID: 7956
	// (get) Token: 0x060178EC RID: 96492 RVA: 0x0068D9E5 File Offset: 0x0068BBE5
	public int VictimCount
	{
		get
		{
			if (this.VictimCountInternal == null)
			{
				this.VictimCountInternal = new int?(this.Data.命中个数);
			}
			return this.VictimCountInternal.Value;
		}
	}

	// Token: 0x17001F15 RID: 7957
	// (get) Token: 0x060178ED RID: 96493 RVA: 0x0068DA15 File Offset: 0x0068BC15
	public int HitConditionTagId
	{
		get
		{
			this.InitHitConditionTag();
			return this.HitConditionTagIdInternal;
		}
	}

	// Token: 0x060178EE RID: 96494 RVA: 0x0068DA24 File Offset: 0x0068BC24
	private void InitHitConditionTag()
	{
		if (!this.HitConditionTagInit)
		{
			this.HitConditionTagInit = true;
			FGameplayTag 命中判定Tag = this.Data.命中判定Tag;
			if (!命中判定Tag.TagName.IsNone())
			{
				this.HitConditionTagIdInternal = 命中判定Tag.TagId();
				return;
			}
			this.HitConditionTagIdInternal = 0;
		}
	}

	// Token: 0x17001F16 RID: 7958
	// (get) Token: 0x060178EF RID: 96495 RVA: 0x0068DA6E File Offset: 0x0068BC6E
	public int HitType
	{
		get
		{
			if (this.HitTypeInternal == null)
			{
				this.HitTypeInternal = new int?((int)this.Data.命中判定类型);
			}
			return this.HitTypeInternal.Value;
		}
	}

	// Token: 0x17001F17 RID: 7959
	// (get) Token: 0x060178F0 RID: 96496 RVA: 0x0068DAA3 File Offset: 0x0068BCA3
	public FName DaHitTypePreset
	{
		get
		{
			this.InitBulletCamp();
			return this.DaHitTypePresetInternal;
		}
	}

	// Token: 0x060178F1 RID: 96497 RVA: 0x0068DAB4 File Offset: 0x0068BCB4
	private void InitBulletCamp()
	{
		if (this.DaHitTypePresetInit)
		{
			return;
		}
		this.DaHitTypePresetInit = true;
		this.DaHitTypePresetInternal = this.Data.命中判定类型预设.GetAssetPathName();
		if (this.DaHitTypePresetInternal != FName.NAME_None)
		{
			BulletCampType_C bulletCampType_C = Singleton<ResourceSystem>.Instance.Load<BulletCampType_C>(this.DaHitTypePresetInternal.ToString(), "js_undefined");
			this.BulletCamp = ((bulletCampType_C != null) ? new int?(bulletCampType_C.阵营) : null);
		}
	}

	// Token: 0x17001F18 RID: 7960
	// (get) Token: 0x060178F2 RID: 96498 RVA: 0x0068DB39 File Offset: 0x0068BD39
	public EBulletRelativeDir RelativeDirection
	{
		get
		{
			if (this.RelativeDirectionInternal == null)
			{
				this.RelativeDirectionInternal = new EBulletRelativeDir?((EBulletRelativeDir)this.Data.子弹受击方向);
			}
			return this.RelativeDirectionInternal.Value;
		}
	}

	// Token: 0x17001F19 RID: 7961
	// (get) Token: 0x060178F3 RID: 96499 RVA: 0x0068DB6E File Offset: 0x0068BD6E
	public EBulletShape Shape
	{
		get
		{
			if (this.ShapeInternal == null)
			{
				this.ShapeInternal = new EBulletShape?((EBulletShape)this.Data.子弹形状);
			}
			return this.ShapeInternal.Value;
		}
	}

	// Token: 0x17001F1A RID: 7962
	// (get) Token: 0x060178F4 RID: 96500 RVA: 0x0068DBA3 File Offset: 0x0068BDA3
	public Rotator AttackDirection
	{
		get
		{
			if (this.AttackDirectionInternal == null)
			{
				this.AttackDirectionInternal = Rotator.Create(this.Data.子弹攻击方向);
			}
			return this.AttackDirectionInternal;
		}
	}

	// Token: 0x17001F1B RID: 7963
	// (get) Token: 0x060178F5 RID: 96501 RVA: 0x0068DBCE File Offset: 0x0068BDCE
	public int TagId
	{
		get
		{
			this.InitTag();
			return this.TagIdInternal;
		}
	}

	// Token: 0x060178F6 RID: 96502 RVA: 0x0068DBDC File Offset: 0x0068BDDC
	private void InitTag()
	{
		if (this.TagInit)
		{
			return;
		}
		this.TagInit = true;
		FGameplayTag 子弹标签 = this.Data.子弹标签;
		if (!子弹标签.TagName.IsNone())
		{
			this.TagIdInternal = 子弹标签.TagId();
			return;
		}
		this.TagIdInternal = 0;
	}

	// Token: 0x17001F1C RID: 7964
	// (get) Token: 0x060178F7 RID: 96503 RVA: 0x0068DC27 File Offset: 0x0068BE27
	public int[] BornRequireTagIds
	{
		get
		{
			this.InitBornTag();
			return this.BornRequireTagIdsInternal;
		}
	}

	// Token: 0x17001F1D RID: 7965
	// (get) Token: 0x060178F8 RID: 96504 RVA: 0x0068DC35 File Offset: 0x0068BE35
	public int[] BornForbidTagIds
	{
		get
		{
			this.InitBornTag();
			return this.BornForbidTagIdsInternal;
		}
	}

	// Token: 0x060178F9 RID: 96505 RVA: 0x0068DC44 File Offset: 0x0068BE44
	private void InitBornTag()
	{
		if (this.BornTagInit)
		{
			return;
		}
		this.BornTagInit = true;
		TArray<FGameplayTag> gameplayTags = this.Data.子弹禁止生成Tag.GameplayTags;
		int num = gameplayTags.Num();
		if (num > 0)
		{
			this.BornForbidTagIdsInternal = new int[num];
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				int num3 = gameplayTags.Get(i).TagId();
				if (num3 != 0)
				{
					this.BornForbidTagIdsInternal[num2++] = num3;
				}
			}
			if (num2 < num)
			{
				Array.Resize<int>(ref this.BornForbidTagIdsInternal, num2);
			}
		}
		TArray<FGameplayTag> gameplayTags2 = this.Data.子弹允许生成Tag.GameplayTags;
		int num4 = gameplayTags2.Num();
		if (num4 > 0)
		{
			this.BornRequireTagIdsInternal = new int[num4];
			int num5 = 0;
			for (int j = 0; j < num4; j++)
			{
				int num6 = gameplayTags2.Get(j).TagId();
				if (num6 != 0)
				{
					this.BornRequireTagIdsInternal[num5++] = num6;
				}
			}
			if (num5 < num4)
			{
				Array.Resize<int>(ref this.BornRequireTagIdsInternal, num5);
			}
		}
	}

	// Token: 0x17001F1E RID: 7966
	// (get) Token: 0x060178FA RID: 96506 RVA: 0x0068DD3F File Offset: 0x0068BF3F
	public FName HitEffectWeakness
	{
		get
		{
			if (!this.HitEffectWeaknessInit)
			{
				this.HitEffectWeaknessInit = true;
				this.HitEffectWeaknessInternal = new FName?(this.Data.弱点被击效果);
			}
			return this.HitEffectWeaknessInternal.Value;
		}
	}

	// Token: 0x17001F1F RID: 7967
	// (get) Token: 0x060178FB RID: 96507 RVA: 0x0068DD74 File Offset: 0x0068BF74
	[Nullable(2)]
	public FName[] MultiHitEffectWeakness
	{
		[NullableContext(2)]
		get
		{
			if (!this.MultiHitEffectWeaknessInit)
			{
				this.MultiHitEffectWeaknessInit = true;
				TArray<FName> 多弱点被击效果 = this.Data.多弱点被击效果;
				int num = 多弱点被击效果.Num();
				if (num > 0)
				{
					this.MultiHitEffectWeaknessInternal = new FName[num];
					for (int i = 0; i < num; i++)
					{
						this.MultiHitEffectWeaknessInternal[i] = 多弱点被击效果.Get(i);
					}
				}
			}
			return this.MultiHitEffectWeaknessInternal;
		}
	}

	// Token: 0x17001F20 RID: 7968
	// (get) Token: 0x060178FC RID: 96508 RVA: 0x0068DDD8 File Offset: 0x0068BFD8
	public int HitCountMax
	{
		get
		{
			if (this.HitCountMaxInternal == null)
			{
				this.HitCountMaxInternal = new int?(this.Data.总作用次数限制);
			}
			return this.HitCountMaxInternal.Value;
		}
	}

	// Token: 0x17001F21 RID: 7969
	// (get) Token: 0x060178FD RID: 96509 RVA: 0x0068DE08 File Offset: 0x0068C008
	public bool DestroyOnSkillEnd
	{
		get
		{
			if (this.DestroyOnSkillEndInternal == null)
			{
				this.DestroyOnSkillEndInternal = new bool?(this.Data.技能结束是否销毁子弹);
			}
			return this.DestroyOnSkillEndInternal.Value;
		}
	}

	// Token: 0x17001F22 RID: 7970
	// (get) Token: 0x060178FE RID: 96510 RVA: 0x0068DE38 File Offset: 0x0068C038
	public float Duration
	{
		get
		{
			if (this.DurationInternal == null)
			{
				this.DurationInternal = new float?(this.Data.持续时间);
			}
			return this.DurationInternal.Value;
		}
	}

	// Token: 0x17001F23 RID: 7971
	// (get) Token: 0x060178FF RID: 96511 RVA: 0x0068DE68 File Offset: 0x0068C068
	public string BlackboardKey
	{
		get
		{
			if (!this.BlackboardKeyInit)
			{
				this.BlackboardKeyInit = true;
				this.BlackboardKeyInternal = this.Data.攻击者黑板Key值;
			}
			return this.BlackboardKeyInternal;
		}
	}

	// Token: 0x17001F24 RID: 7972
	// (get) Token: 0x06017900 RID: 96512 RVA: 0x0068DE90 File Offset: 0x0068C090
	public bool ContinuesCollision
	{
		get
		{
			if (this.ContinuesCollisionInternal == null)
			{
				this.ContinuesCollisionInternal = new bool?(this.Data.是否持续碰撞);
			}
			return this.ContinuesCollisionInternal.Value;
		}
	}

	// Token: 0x17001F25 RID: 7973
	// (get) Token: 0x06017901 RID: 96513 RVA: 0x0068DEC0 File Offset: 0x0068C0C0
	public bool StickGround
	{
		get
		{
			if (this.StickGroundInternal == null)
			{
				this.StickGroundInternal = new bool?(this.Data.是否贴地子弹);
			}
			return this.StickGroundInternal.Value;
		}
	}

	// Token: 0x17001F26 RID: 7974
	// (get) Token: 0x06017902 RID: 96514 RVA: 0x0068DEF0 File Offset: 0x0068C0F0
	public bool StickWater
	{
		get
		{
			if (this.StickWaterInternal == null)
			{
				this.StickWaterInternal = new bool?(this.Data.是否贴水面);
			}
			return this.StickWaterInternal.Value;
		}
	}

	// Token: 0x17001F27 RID: 7975
	// (get) Token: 0x06017903 RID: 96515 RVA: 0x0068DF20 File Offset: 0x0068C120
	public bool NotFollowMovePlatform
	{
		get
		{
			if (this.NotFollowMovePlatformInternal == null)
			{
				this.NotFollowMovePlatformInternal = new bool?(this.Data.不跟随移动平台);
			}
			return this.NotFollowMovePlatformInternal.Value;
		}
	}

	// Token: 0x17001F28 RID: 7976
	// (get) Token: 0x06017904 RID: 96516 RVA: 0x0068DF50 File Offset: 0x0068C150
	public float StickTraceLen
	{
		get
		{
			if (this.StickTraceLenInternal == null)
			{
				this.StickTraceLenInternal = new float?(this.Data.贴地探测距离);
			}
			return this.StickTraceLenInternal.Value;
		}
	}

	// Token: 0x17001F29 RID: 7977
	// (get) Token: 0x06017905 RID: 96517 RVA: 0x0068DF80 File Offset: 0x0068C180
	public int HitCountPerVictim
	{
		get
		{
			if (this.HitCountPerVictimInternal == null)
			{
				this.HitCountPerVictimInternal = new int?(this.Data.每个单位总作用次数);
			}
			return this.HitCountPerVictimInternal.Value;
		}
	}

	// Token: 0x17001F2A RID: 7978
	// (get) Token: 0x06017906 RID: 96518 RVA: 0x0068DFB0 File Offset: 0x0068C1B0
	public Dictionary<EBulletBaseSpecificParam, string> SpecialParams
	{
		get
		{
			if (this.SpecialParamsInternal == null)
			{
				this.SpecialParamsInternal = new Dictionary<EBulletBaseSpecificParam, string>();
				foreach (KeyValuePair<TEnumAsByte<EBulletBaseSpecificParam>, string> keyValuePair in this.Data.特殊参数)
				{
					TEnumAsByte<EBulletBaseSpecificParam> tenumAsByte;
					string text;
					keyValuePair.Deconstruct(out tenumAsByte, out text);
					TEnumAsByte<EBulletBaseSpecificParam> value = tenumAsByte;
					string value2 = text;
					this.SpecialParamsInternal.Add(value, value2);
				}
			}
			return this.SpecialParamsInternal;
		}
	}

	// Token: 0x17001F2B RID: 7979
	// (get) Token: 0x06017907 RID: 96519 RVA: 0x0068E038 File Offset: 0x0068C238
	public float CollisionActiveDelay
	{
		get
		{
			if (this.CollisionActiveDelayInternal == null)
			{
				this.CollisionActiveDelayInternal = new float?(this.Data.碰撞判定延迟);
			}
			return this.CollisionActiveDelayInternal.Value;
		}
	}

	// Token: 0x17001F2C RID: 7980
	// (get) Token: 0x06017908 RID: 96520 RVA: 0x0068E068 File Offset: 0x0068C268
	public float CollisionActiveDuration
	{
		get
		{
			if (this.CollisionActiveDurationInternal == null)
			{
				this.CollisionActiveDurationInternal = new float?(this.Data.碰撞判定时长);
			}
			return this.CollisionActiveDurationInternal.Value;
		}
	}

	// Token: 0x17001F2D RID: 7981
	// (get) Token: 0x06017909 RID: 96521 RVA: 0x0068E098 File Offset: 0x0068C298
	public EBulletSyncTypeTs SyncType
	{
		get
		{
			if (this.SyncTypeInternal == null)
			{
				this.SyncTypeInternal = new EBulletSyncTypeTs?((EBulletSyncTypeTs)this.Data.网络同步类型);
			}
			return this.SyncTypeInternal.Value;
		}
	}

	// Token: 0x17001F2E RID: 7982
	// (get) Token: 0x0601790A RID: 96522 RVA: 0x0068E0CD File Offset: 0x0068C2CD
	public FName BeHitEffect
	{
		get
		{
			if (!this.BeHitEffectInit)
			{
				this.BeHitEffectInit = true;
				this.BeHitEffectInternal = new FName?(this.Data.被击效果);
			}
			return this.BeHitEffectInternal.Value;
		}
	}

	// Token: 0x17001F2F RID: 7983
	// (get) Token: 0x0601790B RID: 96523 RVA: 0x0068E100 File Offset: 0x0068C300
	[Nullable(2)]
	public FName[] MultiBeHitEffect
	{
		[NullableContext(2)]
		get
		{
			if (!this.MultiBeHitEffectInit)
			{
				this.MultiBeHitEffectInit = true;
				TArray<FName> 多被击效果 = this.Data.多被击效果;
				int num = 多被击效果.Num();
				if (num > 0)
				{
					this.MultiBeHitEffectInternal = new FName[num];
					for (int i = 0; i < num; i++)
					{
						this.MultiBeHitEffectInternal[i] = 多被击效果.Get(i);
					}
				}
			}
			return this.MultiBeHitEffectInternal;
		}
	}

	// Token: 0x17001F30 RID: 7984
	// (get) Token: 0x0601790C RID: 96524 RVA: 0x0068E164 File Offset: 0x0068C364
	public Vector BornDistLimit
	{
		get
		{
			if (this.BornDistLimitInternal == null)
			{
				this.BornDistLimitInternal = Vector.Create(this.Data.限制生成距离);
			}
			return this.BornDistLimitInternal;
		}
	}

	// Token: 0x17001F31 RID: 7985
	// (get) Token: 0x0601790D RID: 96525 RVA: 0x0068E18F File Offset: 0x0068C38F
	public int BanHitTagId
	{
		get
		{
			this.InitBanHitTag();
			return this.BanHitTagIdInternal;
		}
	}

	// Token: 0x0601790E RID: 96526 RVA: 0x0068E1A0 File Offset: 0x0068C3A0
	private void InitBanHitTag()
	{
		if (!this.BanHitTagInit)
		{
			this.BanHitTagInit = true;
			FGameplayTag 禁止命中Tag = this.Data.禁止命中Tag;
			if (!禁止命中Tag.TagName.IsNone())
			{
				this.BanHitTagIdInternal = 禁止命中Tag.TagId();
				return;
			}
			this.BanHitTagIdInternal = 0;
		}
	}

	// Token: 0x17001F32 RID: 7986
	// (get) Token: 0x0601790F RID: 96527 RVA: 0x0068E1EA File Offset: 0x0068C3EA
	public bool DebugShowProgress
	{
		get
		{
			if (this.DebugShowProgressInternal == null)
			{
				this.DebugShowProgressInternal = new bool?(this.Data.Debug显示子弹进度);
			}
			return this.DebugShowProgressInternal.Value;
		}
	}

	// Token: 0x17001F33 RID: 7987
	// (get) Token: 0x06017910 RID: 96528 RVA: 0x0068E21A File Offset: 0x0068C41A
	public bool BigRangeHitSceneItem
	{
		get
		{
			if (this.BigRangeHitSceneItemInternal == null)
			{
				this.BigRangeHitSceneItemInternal = new bool?(this.Data.大范围子弹对场景物件生效);
			}
			return this.BigRangeHitSceneItemInternal.Value;
		}
	}

	// Token: 0x17001F34 RID: 7988
	// (get) Token: 0x06017911 RID: 96529 RVA: 0x0068E24A File Offset: 0x0068C44A
	public int HitActorType
	{
		get
		{
			if (this.HitActorTypeInternal == null)
			{
				this.HitActorTypeInternal = new int?((int)this.Data.命中实体类型);
			}
			return this.HitActorTypeInternal.Value;
		}
	}

	// Token: 0x17001F35 RID: 7989
	// (get) Token: 0x06017912 RID: 96530 RVA: 0x0068E27F File Offset: 0x0068C47F
	public int BigRangeSearchType
	{
		get
		{
			if (this.BigRangeSearchTypeInternal == null)
			{
				this.BigRangeSearchTypeInternal = new int?(this.Data.大范围子弹检测方式);
			}
			return this.BigRangeSearchTypeInternal.Value;
		}
	}

	// Token: 0x17001F36 RID: 7990
	// (get) Token: 0x06017913 RID: 96531 RVA: 0x0068E2AF File Offset: 0x0068C4AF
	public bool IsRandomVictim
	{
		get
		{
			if (this.IsRandomVictimInternal == null)
			{
				this.IsRandomVictimInternal = new bool?(this.Data.IsRandomVictim);
			}
			return this.IsRandomVictimInternal.Value;
		}
	}

	// Token: 0x06017914 RID: 96532 RVA: 0x0068E2DF File Offset: 0x0068C4DF
	public BulletDataBase(SReBulletDataBase data)
	{
		this.Data = data;
	}

	// Token: 0x06017915 RID: 96533 RVA: 0x0068E2FC File Offset: 0x0068C4FC
	public bool Preload()
	{
		this.InitBulletCamp();
		this.InitBornTag();
		this.InitHitConditionTag();
		this.InitBanHitTag();
		Vector centerOffset = this.CenterOffset;
		float interval = this.Interval;
		bool shareCounter = this.ShareCounter;
		Vector bornPosition = this.BornPosition;
		EPositionStandard bornPositionStandard = this.BornPositionStandard;
		Vector bornPositionRandom = this.BornPositionRandom;
		Vector size = this.Size;
		Rotator rotator = this.Rotator;
		int hitType = this.HitType;
		EBulletShape shape = this.Shape;
		int tagId = this.TagId;
		float duration = this.Duration;
		float collisionActiveDelay = this.CollisionActiveDelay;
		float collisionActiveDuration = this.CollisionActiveDuration;
		EBulletSyncTypeTs syncType = this.SyncType;
		Vector bornDistLimit = this.BornDistLimit;
		int hitActorType = this.HitActorType;
		return (bool)true;
	}

	// Token: 0x0400B4A2 RID: 46242
	private readonly SReBulletDataBase Data;

	// Token: 0x0400B4A3 RID: 46243
	private bool? IgnoreGradientInternal;

	// Token: 0x0400B4A4 RID: 46244
	[Nullable(2)]
	private Vector CenterOffsetInternal;

	// Token: 0x0400B4A5 RID: 46245
	private long? DamageIdInternal;

	// Token: 0x0400B4A6 RID: 46246
	private bool InitedMultiDamageId;

	// Token: 0x0400B4A7 RID: 46247
	[Nullable(2)]
	private long[] MultiDamageIdInternal;

	// Token: 0x0400B4A8 RID: 46248
	private bool? EnablePartHitAudioInternal;

	// Token: 0x0400B4A9 RID: 46249
	private bool? IntervalAfterHitInternal;

	// Token: 0x0400B4AA RID: 46250
	private float? IntervalInternal;

	// Token: 0x0400B4AB RID: 46251
	private bool? ShareCounterInternal;

	// Token: 0x0400B4AC RID: 46252
	[Nullable(2)]
	private Vector BornPositionInternal;

	// Token: 0x0400B4AD RID: 46253
	private EPositionStandard? BornPositionStandardInternal;

	// Token: 0x0400B4AE RID: 46254
	[Nullable(2)]
	private Vector BornPositionRandomInternal;

	// Token: 0x0400B4AF RID: 46255
	[Nullable(2)]
	private Vector SizeInternal;

	// Token: 0x0400B4B0 RID: 46256
	public bool IsOversizeForTrace;

	// Token: 0x0400B4B1 RID: 46257
	[Nullable(2)]
	private Rotator RotatorInternal;

	// Token: 0x0400B4B2 RID: 46258
	private int? VictimCountInternal;

	// Token: 0x0400B4B3 RID: 46259
	private int HitConditionTagIdInternal;

	// Token: 0x0400B4B4 RID: 46260
	private bool HitConditionTagInit;

	// Token: 0x0400B4B5 RID: 46261
	private int? HitTypeInternal;

	// Token: 0x0400B4B6 RID: 46262
	private bool DaHitTypePresetInit;

	// Token: 0x0400B4B7 RID: 46263
	private FName DaHitTypePresetInternal = FName.NAME_None;

	// Token: 0x0400B4B8 RID: 46264
	public int? BulletCamp;

	// Token: 0x0400B4B9 RID: 46265
	private EBulletRelativeDir? RelativeDirectionInternal;

	// Token: 0x0400B4BA RID: 46266
	private EBulletShape? ShapeInternal;

	// Token: 0x0400B4BB RID: 46267
	[Nullable(2)]
	private Rotator AttackDirectionInternal;

	// Token: 0x0400B4BC RID: 46268
	private int TagIdInternal;

	// Token: 0x0400B4BD RID: 46269
	private bool TagInit;

	// Token: 0x0400B4BE RID: 46270
	[Nullable(2)]
	private int[] BornRequireTagIdsInternal;

	// Token: 0x0400B4BF RID: 46271
	[Nullable(2)]
	private int[] BornForbidTagIdsInternal;

	// Token: 0x0400B4C0 RID: 46272
	private bool BornTagInit;

	// Token: 0x0400B4C1 RID: 46273
	private bool HitEffectWeaknessInit;

	// Token: 0x0400B4C2 RID: 46274
	private FName? HitEffectWeaknessInternal;

	// Token: 0x0400B4C3 RID: 46275
	private bool MultiHitEffectWeaknessInit;

	// Token: 0x0400B4C4 RID: 46276
	[Nullable(2)]
	private FName[] MultiHitEffectWeaknessInternal;

	// Token: 0x0400B4C5 RID: 46277
	private int? HitCountMaxInternal;

	// Token: 0x0400B4C6 RID: 46278
	private bool? DestroyOnSkillEndInternal;

	// Token: 0x0400B4C7 RID: 46279
	private float? DurationInternal;

	// Token: 0x0400B4C8 RID: 46280
	private bool BlackboardKeyInit;

	// Token: 0x0400B4C9 RID: 46281
	[Nullable(2)]
	private string BlackboardKeyInternal;

	// Token: 0x0400B4CA RID: 46282
	private bool? ContinuesCollisionInternal;

	// Token: 0x0400B4CB RID: 46283
	private bool? StickGroundInternal;

	// Token: 0x0400B4CC RID: 46284
	private bool? StickWaterInternal;

	// Token: 0x0400B4CD RID: 46285
	private bool? NotFollowMovePlatformInternal;

	// Token: 0x0400B4CE RID: 46286
	private float? StickTraceLenInternal;

	// Token: 0x0400B4CF RID: 46287
	private int? HitCountPerVictimInternal;

	// Token: 0x0400B4D0 RID: 46288
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<EBulletBaseSpecificParam, string> SpecialParamsInternal;

	// Token: 0x0400B4D1 RID: 46289
	private float? CollisionActiveDelayInternal;

	// Token: 0x0400B4D2 RID: 46290
	private float? CollisionActiveDurationInternal;

	// Token: 0x0400B4D3 RID: 46291
	private EBulletSyncTypeTs? SyncTypeInternal;

	// Token: 0x0400B4D4 RID: 46292
	private bool BeHitEffectInit;

	// Token: 0x0400B4D5 RID: 46293
	private FName? BeHitEffectInternal;

	// Token: 0x0400B4D6 RID: 46294
	private bool MultiBeHitEffectInit;

	// Token: 0x0400B4D7 RID: 46295
	[Nullable(2)]
	private FName[] MultiBeHitEffectInternal;

	// Token: 0x0400B4D8 RID: 46296
	[Nullable(2)]
	private Vector BornDistLimitInternal;

	// Token: 0x0400B4D9 RID: 46297
	private int BanHitTagIdInternal;

	// Token: 0x0400B4DA RID: 46298
	private bool BanHitTagInit;

	// Token: 0x0400B4DB RID: 46299
	private bool? DebugShowProgressInternal;

	// Token: 0x0400B4DC RID: 46300
	private bool? BigRangeHitSceneItemInternal;

	// Token: 0x0400B4DD RID: 46301
	private int? HitActorTypeInternal;

	// Token: 0x0400B4DE RID: 46302
	private int? BigRangeSearchTypeInternal;

	// Token: 0x0400B4DF RID: 46303
	private bool? IsRandomVictimInternal;
}
