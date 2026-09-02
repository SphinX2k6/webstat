using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using CSharpScript.Core.Common;
using UnrealEngine;

// Token: 0x02002DA1 RID: 11681
[NullableContext(1)]
[Nullable(0)]
public class BulletDataLogic
{
	// Token: 0x17001F4D RID: 8013
	// (get) Token: 0x06017932 RID: 96562 RVA: 0x0068E988 File Offset: 0x0068CB88
	public string ComponentName
	{
		get
		{
			if (!this.ComponentNameInit)
			{
				this.ComponentNameInit = true;
				this.ComponentNameInternal = this.Data.只碰撞胶囊体;
			}
			return this.ComponentNameInternal;
		}
	}

	// Token: 0x17001F4E RID: 8014
	// (get) Token: 0x06017933 RID: 96563 RVA: 0x0068E9B0 File Offset: 0x0068CBB0
	public EBulletHitDirectionType HitDirectionType
	{
		get
		{
			if (this.HitDirectionTypeInternal == null)
			{
				this.HitDirectionTypeInternal = new EBulletHitDirectionType?((EBulletHitDirectionType)this.Data.子弹受击类型角度判断);
			}
			return this.HitDirectionTypeInternal.Value;
		}
	}

	// Token: 0x17001F4F RID: 8015
	// (get) Token: 0x06017934 RID: 96564 RVA: 0x0068E9E5 File Offset: 0x0068CBE5
	public bool DestroyOnHitCharacter
	{
		get
		{
			if (this.DestroyOnHitCharacterInternal == null)
			{
				this.DestroyOnHitCharacterInternal = new bool?(this.Data.子弹碰撞单位销毁);
			}
			return this.DestroyOnHitCharacterInternal.Value;
		}
	}

	// Token: 0x17001F50 RID: 8016
	// (get) Token: 0x06017935 RID: 96565 RVA: 0x0068EA15 File Offset: 0x0068CC15
	public bool DestroyOnHitObstacle
	{
		get
		{
			if (this.DestroyOnHitObstacleInternal == null)
			{
				this.DestroyOnHitObstacleInternal = new bool?(this.Data.子弹碰撞障碍销毁);
			}
			return this.DestroyOnHitObstacleInternal.Value;
		}
	}

	// Token: 0x17001F51 RID: 8017
	// (get) Token: 0x06017936 RID: 96566 RVA: 0x0068EA45 File Offset: 0x0068CC45
	public FName ProfileName
	{
		get
		{
			if (!this.ProfileNameInit)
			{
				this.ProfileNameInit = true;
				this.ProfileNameInternal = new FName?(this.Data.子弹碰撞预设);
			}
			return this.ProfileNameInternal.Value;
		}
	}

	// Token: 0x17001F52 RID: 8018
	// (get) Token: 0x06017937 RID: 96567 RVA: 0x0068EA77 File Offset: 0x0068CC77
	public EBulletType Type
	{
		get
		{
			if (this.TypeInternal == null)
			{
				this.TypeInternal = new EBulletType?((EBulletType)this.Data.子弹类型);
			}
			return this.TypeInternal.Value;
		}
	}

	// Token: 0x17001F53 RID: 8019
	// (get) Token: 0x06017938 RID: 96568 RVA: 0x0068EAAC File Offset: 0x0068CCAC
	public bool InteractWithWater
	{
		get
		{
			if (this.InteractWithWaterInternal == null)
			{
				this.InteractWithWaterInternal = new bool?(this.Data.开启水面交互);
			}
			return this.InteractWithWaterInternal.Value;
		}
	}

	// Token: 0x17001F54 RID: 8020
	// (get) Token: 0x06017939 RID: 96569 RVA: 0x0068EADC File Offset: 0x0068CCDC
	public bool InteractWithAirWall
	{
		get
		{
			if (this.InteractWithAirWallInternal == null)
			{
				this.InteractWithAirWallInternal = new bool?(this.Data.开启空气墙交互);
			}
			return this.InteractWithAirWallInternal.Value;
		}
	}

	// Token: 0x17001F55 RID: 8021
	// (get) Token: 0x0601793A RID: 96570 RVA: 0x0068EB0C File Offset: 0x0068CD0C
	public int ReboundChannel
	{
		get
		{
			if (this.ReboundChannelInternal == null)
			{
				this.ReboundChannelInternal = new int?(this.Data.弹反通道);
			}
			return this.ReboundChannelInternal.Value;
		}
	}

	// Token: 0x17001F56 RID: 8022
	// (get) Token: 0x0601793B RID: 96571 RVA: 0x0068EB3C File Offset: 0x0068CD3C
	public bool CanCounterAttack
	{
		get
		{
			if (this.CanCounterAttackInternal == null)
			{
				this.CanCounterAttackInternal = new bool?(this.Data.是否可以触发拼刀);
			}
			return this.CanCounterAttackInternal.Value;
		}
	}

	// Token: 0x17001F57 RID: 8023
	// (get) Token: 0x0601793C RID: 96572 RVA: 0x0068EB6C File Offset: 0x0068CD6C
	public bool CounterAttackIgnoreAngle
	{
		get
		{
			if (this.CounterAttackIgnoreAngleInternal == null)
			{
				this.CounterAttackIgnoreAngleInternal = new bool?(this.Data.拼刀忽略角度);
			}
			return this.CounterAttackIgnoreAngleInternal.Value;
		}
	}

	// Token: 0x17001F58 RID: 8024
	// (get) Token: 0x0601793D RID: 96573 RVA: 0x0068EB9C File Offset: 0x0068CD9C
	public bool CounterAttackIgnoreDist
	{
		get
		{
			if (this.CounterAttackIgnoreDistanceInternal == null)
			{
				this.CounterAttackIgnoreDistanceInternal = new bool?(this.Data.拼刀忽略距离);
			}
			return this.CounterAttackIgnoreDistanceInternal.Value;
		}
	}

	// Token: 0x17001F59 RID: 8025
	// (get) Token: 0x0601793E RID: 96574 RVA: 0x0068EBCC File Offset: 0x0068CDCC
	public bool CanBreakWindupAttack
	{
		get
		{
			if (this.CanBreakWindupAttackInternal == null)
			{
				this.CanBreakWindupAttackInternal = new bool?(this.Data.触发前摇拼刀);
			}
			return this.CanBreakWindupAttackInternal.Value;
		}
	}

	// Token: 0x17001F5A RID: 8026
	// (get) Token: 0x0601793F RID: 96575 RVA: 0x0068EBFC File Offset: 0x0068CDFC
	public bool CanVisionCounterAttack
	{
		get
		{
			if (this.CanVisionCounterAttackInternal == null)
			{
				this.CanVisionCounterAttackInternal = new bool?(this.Data.是否可以触发对策);
			}
			return this.CanVisionCounterAttackInternal.Value;
		}
	}

	// Token: 0x17001F5B RID: 8027
	// (get) Token: 0x06017940 RID: 96576 RVA: 0x0068EC2C File Offset: 0x0068CE2C
	public bool CanDodge
	{
		get
		{
			if (this.CanDodgeInternal == null)
			{
				this.CanDodgeInternal = new bool?(this.Data.是否可以触发极限闪避);
			}
			return this.CanDodgeInternal.Value;
		}
	}

	// Token: 0x17001F5C RID: 8028
	// (get) Token: 0x06017941 RID: 96577 RVA: 0x0068EC5C File Offset: 0x0068CE5C
	public bool DestroyOnCountZero
	{
		get
		{
			if (this.DestroyOnCountZeroInternal == null)
			{
				this.DestroyOnCountZeroInternal = new bool?(this.Data.次数为0时销毁);
			}
			return this.DestroyOnCountZeroInternal.Value;
		}
	}

	// Token: 0x17001F5D RID: 8029
	// (get) Token: 0x06017942 RID: 96578 RVA: 0x0068EC8C File Offset: 0x0068CE8C
	public int[] PresentTagIds
	{
		get
		{
			this.InitPresetTag();
			return this.PresentTagIdsInternal;
		}
	}

	// Token: 0x06017943 RID: 96579 RVA: 0x0068EC9C File Offset: 0x0068CE9C
	private void InitPresetTag()
	{
		if (!this.PresetTagInit)
		{
			this.PresetTagInit = true;
			List<int> list = new List<int>();
			TArray<FGameplayTag> gameplayTags = this.Data.预设标签.GameplayTags;
			int num = gameplayTags.Num();
			for (int i = 0; i < num; i++)
			{
				if (gameplayTags.IsValidIndex(i))
				{
					FGameplayTag tag = gameplayTags.Get(i);
					if (!tag.TagName.IsNone())
					{
						list.Add(tag.TagId());
					}
				}
			}
			this.PresentTagIdsInternal = list.ToArray();
		}
	}

	// Token: 0x17001F5E RID: 8030
	// (get) Token: 0x06017944 RID: 96580 RVA: 0x0068ED1B File Offset: 0x0068CF1B
	public bool IgnoreWater
	{
		get
		{
			if (this.IgnoreWaterInternal == null)
			{
				this.IgnoreWaterInternal = new bool?(this.Data.忽略水体);
			}
			return this.IgnoreWaterInternal.Value;
		}
	}

	// Token: 0x17001F5F RID: 8031
	// (get) Token: 0x06017945 RID: 96581 RVA: 0x0068ED4B File Offset: 0x0068CF4B
	public bool DestroyOnFrozen
	{
		get
		{
			if (this.DestroyOnFrozenInternal == null)
			{
				this.DestroyOnFrozenInternal = new bool?(this.Data.冰冻时销毁);
			}
			return this.DestroyOnFrozenInternal.Value;
		}
	}

	// Token: 0x06017946 RID: 96582 RVA: 0x0068ED7C File Offset: 0x0068CF7C
	public BulletDataLogic(TSoftObjectPtr<BulletLogicType_C> data)
	{
		string text = data.ToAssetPathName();
		if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
		{
			if (!string.IsNullOrEmpty(text) && !(text == "None"))
			{
				TSoftObjectPtr<UObject> tsoftObjectPtr = data.As<UObject>();
				if (UKismetSystemLibrary.IsValidSoftObjectReference(tsoftObjectPtr))
				{
					goto IL_6F;
				}
			}
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Bullet;
			Entity entity = null;
			string message = "子弹配置出错，没有配置逻辑设置.预设";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("配置路径", text ?? "");
			instance.Error(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		IL_6F:
		this.Data = Singleton<ResourceSystem>.Instance.Load<BulletLogicType_C>(text, "js_undefined");
		if (this.Data == null)
		{
			if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
			{
				CombatLog instance2 = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Bullet;
				Entity entity2 = null;
				string message2 = "子弹配置出错，逻辑设置.预设 资源加载失败";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("配置路径", text ?? "");
				instance2.Error(flag2, entity2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			return;
		}
		if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug && !this.ProfileName.ToString().ToLower().StartsWith("bullet_"))
		{
			CombatLog instance3 = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag3 = CombatLog.EDebugModule.Bullet;
			Entity entity3 = null;
			string message3 = "子弹配置出错，逻辑设置.预设.子弹碰撞预设 填写的值不对";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("配置路径", text);
			instance3.Error(flag3, entity3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
		}
	}

	// Token: 0x06017947 RID: 96583 RVA: 0x0068EEAA File Offset: 0x0068D0AA
	public void Preload()
	{
		this.InitPresetTag();
	}

	// Token: 0x0400B500 RID: 46336
	[Nullable(2)]
	public readonly BulletLogicType_C Data;

	// Token: 0x0400B501 RID: 46337
	[Nullable(2)]
	private string ComponentNameInternal;

	// Token: 0x0400B502 RID: 46338
	private bool ComponentNameInit;

	// Token: 0x0400B503 RID: 46339
	private EBulletHitDirectionType? HitDirectionTypeInternal;

	// Token: 0x0400B504 RID: 46340
	private bool? DestroyOnHitCharacterInternal;

	// Token: 0x0400B505 RID: 46341
	private bool? DestroyOnHitObstacleInternal;

	// Token: 0x0400B506 RID: 46342
	private FName? ProfileNameInternal;

	// Token: 0x0400B507 RID: 46343
	private bool ProfileNameInit;

	// Token: 0x0400B508 RID: 46344
	private EBulletType? TypeInternal;

	// Token: 0x0400B509 RID: 46345
	private bool? InteractWithWaterInternal;

	// Token: 0x0400B50A RID: 46346
	private bool? InteractWithAirWallInternal;

	// Token: 0x0400B50B RID: 46347
	private int? ReboundChannelInternal;

	// Token: 0x0400B50C RID: 46348
	private bool? CanCounterAttackInternal;

	// Token: 0x0400B50D RID: 46349
	private bool? CounterAttackIgnoreAngleInternal;

	// Token: 0x0400B50E RID: 46350
	private bool? CounterAttackIgnoreDistanceInternal;

	// Token: 0x0400B50F RID: 46351
	private bool? CanBreakWindupAttackInternal;

	// Token: 0x0400B510 RID: 46352
	private bool? CanVisionCounterAttackInternal;

	// Token: 0x0400B511 RID: 46353
	private bool? CanDodgeInternal;

	// Token: 0x0400B512 RID: 46354
	private bool? DestroyOnCountZeroInternal;

	// Token: 0x0400B513 RID: 46355
	[Nullable(2)]
	private int[] PresentTagIdsInternal;

	// Token: 0x0400B514 RID: 46356
	private bool PresetTagInit;

	// Token: 0x0400B515 RID: 46357
	private bool? IgnoreWaterInternal;

	// Token: 0x0400B516 RID: 46358
	private bool? DestroyOnFrozenInternal;
}
