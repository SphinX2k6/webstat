using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.NewWorld.SceneItem.CurveControl;

namespace CSharpScript.Game.NewWorld.SceneItem.Common.Component
{
	// Token: 0x02004884 RID: 18564
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneItemCurveControlComponent : EntityComponent
	{
		// Token: 0x060304DE RID: 197854 RVA: 0x00BC5410 File Offset: 0x00BC3610
		protected override bool OnInitData(IEntityArgs args = null)
		{
			CreateEntityData createEntityData = (args != null) ? args.GetP1<CreateEntityData>() : null;
			CurveControlComponent curveControlComponent = ((createEntityData != null) ? createEntityData.GetParam<SceneItemCurveControlComponent>() : null) as CurveControlComponent;
			this.ActorComp = base.Entity.GetComponent<BaseActorComponent>();
			CurveControlFactory instance = Singleton<CurveControlFactory>.Instance;
			IChargeSlashControl curveControlConfig = curveControlComponent.CurveControlConfig;
			this.CurveControl = instance.CreateCurveControl((curveControlConfig != null) ? new ECurveControlType?(curveControlConfig.Type) : null);
			if (this.CurveControl == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItemCurveControl;
				ELogAuthor author = ELogAuthor.CH;
				string message = "[CurveControl] CreateCurveControl Failed";
				string item = "PbDataId";
				BaseActorComponent actorComp = this.ActorComp;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (actorComp != null) ? new int?(actorComp.CreatureData.GetPbDataId()) : null);
				instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			this.CurveControl.Init(base.Entity, curveControlComponent);
			base.DisableByKey(EEntityDisableKey.CurveControlComponent, false);
			return true;
		}

		// Token: 0x060304DF RID: 197855 RVA: 0x00BC54F4 File Offset: 0x00BC36F4
		protected override void OnTick(float delta)
		{
			if (this.FirstTick)
			{
				this.FirstTick = false;
				return;
			}
			if (this.CurveControl == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItemCurveControl;
				ELogAuthor author = ELogAuthor.CH;
				string message = "[CurveControl] OnTick Failed";
				string item = "PbDataId";
				BaseActorComponent actorComp = this.ActorComp;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (actorComp != null) ? new int?(actorComp.CreatureData.GetPbDataId()) : null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.DisableByKey(EEntityDisableKey.CurveControlComponent, false);
				this.FirstTick = true;
				return;
			}
			if (!this.CurveControl.Tick(delta))
			{
				base.DisableByKey(EEntityDisableKey.CurveControlComponent, false);
				this.FirstTick = true;
			}
		}

		// Token: 0x060304E0 RID: 197856 RVA: 0x00BC5598 File Offset: 0x00BC3798
		public void StartPerformance(float delayTime)
		{
			if (this.CurveControl == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItemCurveControl;
				ELogAuthor author = ELogAuthor.CH;
				string message = "[CurveControl] StartPerformance Failed";
				string item = "PbDataId";
				BaseActorComponent actorComp = this.ActorComp;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (actorComp != null) ? new int?(actorComp.CreatureData.GetPbDataId()) : null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			Entity entity = (baseCharacter != null) ? baseCharacter.GetEntityNoBlueprint() : null;
			if (entity == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.SceneItemCurveControl, ELogAuthor.CH, "curCharEntity is null", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			BaseAttributeComponent component = entity.GetComponent<BaseAttributeComponent>();
			if (component == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.SceneItemCurveControl, ELogAuthor.CH, "attrComp is null", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			float currentValue = component.GetCurrentValue(EAttributeType.SpecialEnergy2Max);
			float num = component.GetCurrentValue(EAttributeType.SpecialEnergy1Max) / currentValue * 0.05f;
			float num2 = component.GetCurrentValue(EAttributeType.SpecialEnergy3Max) / currentValue * 0.05f - num;
			this.CurveControl.SetAllTime((num - delayTime) * 1000f, num2 * 1000f, 2500f);
			this.CurveControl.Start();
			base.EnableByKey(EEntityDisableKey.CurveControlComponent, true);
		}

		// Token: 0x060304E1 RID: 197857 RVA: 0x00BC56C4 File Offset: 0x00BC38C4
		public void StopPerformance()
		{
			if (this.CurveControl == null || this.CurveControl.IsStop())
			{
				return;
			}
			this.CurveControl.Stop(false);
		}

		// Token: 0x060304E2 RID: 197858 RVA: 0x00BC56E8 File Offset: 0x00BC38E8
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemCurveControlComponent sceneItemCurveControlComponent = (SceneItemCurveControlComponent)componentTemplate;
			if (base.CanResetComponentProperty("CurveControl"))
			{
				if (sceneItemCurveControlComponent.CurveControl == null)
				{
					this.CurveControl = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CurveControlBase>(this.CurveControl), "CurveControl"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (sceneItemCurveControlComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("FirstTick"))
			{
				this.FirstTick = sceneItemCurveControlComponent.FirstTick;
			}
			return true;
		}

		// Token: 0x0401BBE4 RID: 113636
		private const float STEP_TIME = 0.05f;

		// Token: 0x0401BBE5 RID: 113637
		private CurveControlBase CurveControl;

		// Token: 0x0401BBE6 RID: 113638
		private BaseActorComponent ActorComp;

		// Token: 0x0401BBE7 RID: 113639
		private bool FirstTick = true;
	}
}
