using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x02003117 RID: 12567
public class BulletPatternComponent : EntityComponent, IStaticVariableResetter
{
	// Token: 0x0601A046 RID: 106566 RVA: 0x0079F228 File Offset: 0x0079D428
	static BulletPatternComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(BulletPatternComponent.CreateStaticDefaultValue), new Action(BulletPatternComponent.ResetStaticDefaultValue));
	}

	// Token: 0x0601A047 RID: 106567 RVA: 0x0079F247 File Offset: 0x0079D447
	[NullableContext(2)]
	public static UKuroFastCollisionAlgorithm GetKuroFastCollisionAlgorithm()
	{
		return BulletPatternComponent.Algorithm;
	}

	// Token: 0x1700234E RID: 9038
	// (get) Token: 0x0601A048 RID: 106568 RVA: 0x0079F24E File Offset: 0x0079D44E
	public bool HasBulletPatternSkill
	{
		get
		{
			return this.HasBulletPatternSkillInternal;
		}
	}

	// Token: 0x0601A049 RID: 106569 RVA: 0x0079F258 File Offset: 0x0079D458
	protected override bool OnStart()
	{
		BaseSkillComponent component = base.Entity.GetComponent<BaseSkillComponent>();
		this.HasBulletPatternSkillInternal = (((component != null) ? component.DtKuroBulletInfo : null) != null);
		if (this.HasBulletPatternSkillInternal)
		{
			this.StartBulletPatternEnvironment();
		}
		return true;
	}

	// Token: 0x0601A04A RID: 106570 RVA: 0x0079F295 File Offset: 0x0079D495
	protected override bool OnEnd()
	{
		if (this.HasBulletPatternSkillInternal)
		{
			this.StopBulletPatternEnvironment();
		}
		return true;
	}

	// Token: 0x0601A04B RID: 106571 RVA: 0x0079F2A8 File Offset: 0x0079D4A8
	private void StartBulletPatternEnvironment()
	{
		if (++BulletPatternComponent.ActiveInstanceCount == 1 && ModelBase<BulletModel>.Instance.GetKuroBulletWorld() == null)
		{
			BulletPatternComponent.Algorithm = ControllerBase<KuroFastCollisionController>.Instance.CreateAlgorithm(UKuroFastCollisionAlgorithm_Grid.StaticClass().ToWeakClass(), true);
			ModelBase<BulletModel>.Instance.StartKuroBulletWorld(BulletPatternComponent.Algorithm, true);
			UBulletWorld kuroBulletWorld = ModelBase<BulletModel>.Instance.GetKuroBulletWorld();
			CharacterActorComponent component = base.Entity.GetComponent<CharacterActorComponent>();
			FVectorDouble? fvectorDouble = (component != null) ? new FVectorDouble?(component.ActorLocation) : null;
			if (fvectorDouble != null && kuroBulletWorld != null)
			{
				kuroBulletWorld.EnableFlatGroundByAbovePoint(fvectorDouble.Value);
			}
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.BulletPatternEnvironmentChanged, true);
		}
	}

	// Token: 0x0601A04C RID: 106572 RVA: 0x0079F360 File Offset: 0x0079D560
	private void StopBulletPatternEnvironment()
	{
		if (--BulletPatternComponent.ActiveInstanceCount == 0 && BulletPatternComponent.Algorithm != null)
		{
			ControllerBase<KuroFastCollisionController>.Instance.DestroyAlgorithm(BulletPatternComponent.Algorithm);
			ModelBase<BulletModel>.Instance.StopKuroBulletWorld();
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.BulletPatternEnvironmentChanged, false);
			BulletPatternComponent.Algorithm = null;
		}
	}

	// Token: 0x0601A04D RID: 106573 RVA: 0x0079F3B3 File Offset: 0x0079D5B3
	public static void CreateStaticDefaultValue()
	{
		BulletPatternComponent.Algorithm = null;
		BulletPatternComponent.ActiveInstanceCount = 0;
	}

	// Token: 0x0601A04E RID: 106574 RVA: 0x0079F3C1 File Offset: 0x0079D5C1
	public static void ResetStaticDefaultValue()
	{
		BulletPatternComponent.Algorithm = null;
		BulletPatternComponent.ActiveInstanceCount = 0;
	}

	// Token: 0x0601A04F RID: 106575 RVA: 0x0079F3D0 File Offset: 0x0079D5D0
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		BulletPatternComponent bulletPatternComponent = (BulletPatternComponent)componentTemplate;
		if (base.CanResetComponentProperty("HasBulletPatternSkillInternal"))
		{
			this.HasBulletPatternSkillInternal = bulletPatternComponent.HasBulletPatternSkillInternal;
		}
		return true;
	}

	// Token: 0x0400D0B2 RID: 53426
	[Nullable(2)]
	private static UKuroFastCollisionAlgorithm Algorithm;

	// Token: 0x0400D0B3 RID: 53427
	private static int ActiveInstanceCount;

	// Token: 0x0400D0B4 RID: 53428
	private bool HasBulletPatternSkillInternal;
}
