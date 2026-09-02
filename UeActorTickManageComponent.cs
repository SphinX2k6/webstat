using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02003226 RID: 12838
[NullableContext(1)]
[Nullable(0)]
public class UeActorTickManageComponent : EntityComponent, IComponentDependency
{
	// Token: 0x1700243A RID: 9274
	// (get) Token: 0x0601AB63 RID: 109411 RVA: 0x007F3F33 File Offset: 0x007F2133
	public static Type[] Dependencies
	{
		get
		{
			return new Type[]
			{
				typeof(BaseActorComponent)
			};
		}
	}

	// Token: 0x0601AB64 RID: 109412 RVA: 0x007F3F48 File Offset: 0x007F2148
	[NullableContext(2)]
	protected override bool OnInitData(IEntityArgs args = null)
	{
		this.ActorComp = base.Entity.GetComponent<BaseActorComponent>();
		return true;
	}

	// Token: 0x0601AB65 RID: 109413 RVA: 0x007F3F5C File Offset: 0x007F215C
	protected override void OnActivate()
	{
		this.ActorComp.Owner.SetKuroOnlyTickOutside(true);
	}

	// Token: 0x0601AB66 RID: 109414 RVA: 0x007F3F70 File Offset: 0x007F2170
	protected override void OnTick(float delta)
	{
		if (Singleton<PerformanceController>.Instance.IsOpenCatchWorldEntity)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(42, 3);
			defaultInterpolatedStringHandler.AppendLiteral("DeltaSeconds: ");
			defaultInterpolatedStringHandler.AppendFormatted(base.Entity.GetDeltaSeconds().ToString("F2"));
			defaultInterpolatedStringHandler.AppendLiteral(", TickInterval: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(base.Entity.GetTickInterval());
			defaultInterpolatedStringHandler.AppendLiteral(", Distance: ");
			defaultInterpolatedStringHandler.AppendFormatted(base.Entity.DistanceWithCamera.ToString("F2"));
			string text = defaultInterpolatedStringHandler.ToStringAndClear();
			CharacterUnifiedStateComponent component = base.Entity.GetComponent<CharacterUnifiedStateComponent>();
			if (component != null)
			{
				bool isInFighting = component.IsInFighting;
				string str = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
				defaultInterpolatedStringHandler.AppendLiteral(" IsInFight: ");
				defaultInterpolatedStringHandler.AppendFormatted<bool>(isInFighting);
				text = str + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			Stat.CreateNoFlameGraph(text, "", "");
		}
		this.ActorComp.Owner.KuroTickActorOutside(delta * 0.001f);
	}

	// Token: 0x0601AB67 RID: 109415 RVA: 0x007F4080 File Offset: 0x007F2280
	public unsafe int DisableTickWithLog(string reason)
	{
		int num = base.Disable(reason);
		CreatureController instance = ControllerBase<CreatureController>.Instance;
		CreatureDataComponent creatureData = this.ActorComp.CreatureData;
		EEntityType? eentityType = (creatureData != null) ? new EEntityType?(creatureData.GetEntityType()) : null;
		if (instance.CheckEnableEntityLog((eentityType != null) ? new OneOf<EEntityType, EntityHandle>?(eentityType.GetValueOrDefault()) : null))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "DisableTick";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "CreatureDataId";
			CreatureDataComponent creatureData2 = this.ActorComp.CreatureData;
			ptr = new ValueTuple<string, object>(item, (creatureData2 != null) ? new long?(creatureData2.GetCreatureDataId()) : null);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item2 = "PbDataId";
			CreatureDataComponent creatureData3 = this.ActorComp.CreatureData;
			ptr2 = new ValueTuple<string, object>(item2, (creatureData3 != null) ? new int?(creatureData3.GetPbDataId()) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Handle", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Reason", reason);
			instance2.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
		return num;
	}

	// Token: 0x0601AB68 RID: 109416 RVA: 0x007F41CC File Offset: 0x007F23CC
	public unsafe bool EnableTickWithLog(int handle, string reason)
	{
		CreatureController instance = ControllerBase<CreatureController>.Instance;
		CreatureDataComponent creatureData = this.ActorComp.CreatureData;
		EEntityType? eentityType = (creatureData != null) ? new EEntityType?(creatureData.GetEntityType()) : null;
		if (instance.CheckEnableEntityLog((eentityType != null) ? new OneOf<EEntityType, EntityHandle>?(eentityType.GetValueOrDefault()) : null))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "EnableTick";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "CreatureDataId";
			CreatureDataComponent creatureData2 = this.ActorComp.CreatureData;
			ptr = new ValueTuple<string, object>(item, (creatureData2 != null) ? new long?(creatureData2.GetCreatureDataId()) : null);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item2 = "PbDataId";
			CreatureDataComponent creatureData3 = this.ActorComp.CreatureData;
			ptr2 = new ValueTuple<string, object>(item2, (creatureData3 != null) ? new int?(creatureData3.GetPbDataId()) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Handle", handle);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Reason", reason);
			instance2.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
		return base.Enable(new int?(handle), reason);
	}

	// Token: 0x0601AB69 RID: 109417 RVA: 0x007F4318 File Offset: 0x007F2518
	public string DumpDisableTickInfo()
	{
		return base.DumpDisableInfo();
	}

	// Token: 0x0601AB6A RID: 109418 RVA: 0x007F4320 File Offset: 0x007F2520
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		UeActorTickManageComponent ueActorTickManageComponent = (UeActorTickManageComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (ueActorTickManageComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400D885 RID: 55429
	[Nullable(2)]
	private BaseActorComponent ActorComp;
}
