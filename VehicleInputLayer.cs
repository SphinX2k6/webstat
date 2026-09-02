using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Blueprints;
using AkiClient.Game.Aki.Character.Input.Structures;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using UnrealEngine;

// Token: 0x020030AA RID: 12458
[NullableContext(2)]
[Nullable(0)]
public class VehicleInputLayer : InputLayer
{
	// Token: 0x06019AB7 RID: 105143 RVA: 0x00776838 File Offset: 0x00774A38
	[NullableContext(1)]
	[return: Nullable(2)]
	private IVehicleInputInfo ResolveInputInfo(Entity entity)
	{
		VehicleActorComponent component = entity.GetComponent<VehicleActorComponent>();
		UnrealScriptStructProxy self;
		if (component == null)
		{
			self = null;
		}
		else
		{
			TsBaseVehicle vehicleOwner = component.VehicleOwner;
			self = ((vehicleOwner != null) ? vehicleOwner.InputComponentClass : null);
		}
		if (self != null)
		{
			return new VehicleInputInfo
			{
				InputClassPath = component.VehicleOwner.InputComponentClass.AssetPathName.ToString(),
				Owner = component.VehicleOwner
			};
		}
		CharacterActorComponent component2 = entity.GetComponent<CharacterActorComponent>();
		if (((component2 != null) ? component2.Actor : null) != null)
		{
			return new VehicleInputInfo
			{
				InputClassPath = "/Game/Aki/Character/NPC/BP_InputComponent_NpcVehicle.BP_InputComponent_NpcVehicle_C",
				Owner = component2.Actor
			};
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Input;
		ELogAuthor author = ELogAuthor.XDW;
		string message = "[VehicleInputLayer] 实体没有可用类型的ActorComponent";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", entity.Id);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x06019AB8 RID: 105144 RVA: 0x00776908 File Offset: 0x00774B08
	[NullableContext(1)]
	public unsafe void Init(EntityHandle entityHandle)
	{
		WorldEntity entity = entityHandle.Entity;
		IVehicleInputInfo inputInfo = this.ResolveInputInfo(entity);
		if (inputInfo == null)
		{
			return;
		}
		this.ResetBpInputComp();
		if (this.BpInputComp != null)
		{
			return;
		}
		if (Singleton<ResourceSystem>.Instance.LoadAsync<UClass>(inputInfo.InputClassPath, delegate([Nullable(2)] UClass inputComponentClass, string _)
		{
			ABaseCharacter owner = inputInfo.Owner;
			if (owner == null || !owner.IsValid())
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Input;
				ELogAuthor author2 = ELogAuthor.XDW;
				string message2 = "[VehicleInputLayer] 异步加载完资源后Owner无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", entity.Id);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.BpInputComp = (inputInfo.Owner.AddComponentByClass(inputComponentClass, false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as BP_InputBase_C);
			BP_InputBase_C bpInputComp = this.BpInputComp;
			if (bpInputComp == null || !bpInputComp.IsValid())
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Input;
				ELogAuthor author3 = ELogAuthor.XDW;
				string message3 = "[VehicleInputLayer] 添加InputComponent失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityId", entity.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("InputClassPath", inputInfo.InputClassPath);
				instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				this.BpInputComp = null;
				return;
			}
			this.BpInputComp.OwnerActor = inputInfo.Owner;
			this.BpInputCompOrigin = this.BpInputComp;
		}, 100, "js_undefined") == -1)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Input;
			ELogAuthor author = ELogAuthor.XDW;
			string message = "[VehicleInputLayer] 异步加载资源失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("InputClassPath", inputInfo.InputClassPath);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}

	// Token: 0x06019AB9 RID: 105145 RVA: 0x007769EF File Offset: 0x00774BEF
	public override void Clear()
	{
		this.BpInputComp = null;
		this.BpInputCompOrigin = null;
	}

	// Token: 0x06019ABA RID: 105146 RVA: 0x007769FF File Offset: 0x00774BFF
	public override EInputLayer GetLayerType()
	{
		return EInputLayer.Vehicle;
	}

	// Token: 0x06019ABB RID: 105147 RVA: 0x00776A04 File Offset: 0x00774C04
	public override SInputCommand HandlePress(EInputAction action, float time)
	{
		if (this.BpInputComp == null)
		{
			return null;
		}
		switch (action)
		{
		case 1:
			return this.BpInputComp.跳跃按下(time);
		case 2:
			return this.BpInputComp.攀爬按下(time);
		case 3:
			return this.BpInputComp.走跑切换按下(time);
		case 4:
			return this.BpInputComp.攻击按下(time);
		case 5:
			return this.BpInputComp.闪避按下(time);
		case 6:
			return this.BpInputComp.技能1按下(time);
		case 7:
			return this.BpInputComp.幻象1按下(time);
		case 8:
			return this.BpInputComp.大招按下(time);
		case 9:
			return this.BpInputComp.幻象2按下(time);
		case 10:
			return this.BpInputComp.切换角色1按下(time);
		case 11:
			return this.BpInputComp.切换角色2按下(time);
		case 12:
			return this.BpInputComp.切换角色3按下(time);
		case 14:
			return this.BpInputComp.瞄准按下(time);
		case 15:
			return this.BpInputComp.通用交互按下(time);
		}
		return null;
	}

	// Token: 0x06019ABC RID: 105148 RVA: 0x00776B24 File Offset: 0x00774D24
	public override SInputCommand HandleRelease(EInputAction action, float time)
	{
		if (this.BpInputComp == null)
		{
			return null;
		}
		switch (action)
		{
		case 1:
			return this.BpInputComp.跳跃抬起(time);
		case 2:
			return this.BpInputComp.攀爬抬起(time);
		case 3:
			return this.BpInputComp.走跑切换抬起(time);
		case 4:
			return this.BpInputComp.攻击抬起(time);
		case 5:
			return this.BpInputComp.闪避抬起(time);
		case 6:
			return this.BpInputComp.技能1抬起(time);
		case 7:
			return this.BpInputComp.幻象1抬起(time);
		case 8:
			return this.BpInputComp.大招抬起(time);
		case 9:
			return this.BpInputComp.幻象2抬起(time);
		case 10:
			return this.BpInputComp.切换角色1抬起(time);
		case 11:
			return this.BpInputComp.切换角色2抬起(time);
		case 12:
			return this.BpInputComp.切换角色3抬起(time);
		case 14:
			return this.BpInputComp.瞄准抬起(time);
		}
		return null;
	}

	// Token: 0x06019ABD RID: 105149 RVA: 0x00776C34 File Offset: 0x00774E34
	public override SInputCommand HandleHold(EInputAction action, float time)
	{
		if (this.BpInputComp == null)
		{
			return null;
		}
		switch (action)
		{
		case 1:
			return this.BpInputComp.跳跃长按(time);
		case 2:
			return this.BpInputComp.攀爬长按(time);
		case 3:
			return this.BpInputComp.走跑切换长按(time);
		case 4:
			return this.BpInputComp.攻击长按(time);
		case 5:
			return this.BpInputComp.闪避长按(time);
		case 6:
			return this.BpInputComp.技能1长按(time);
		case 7:
			return this.BpInputComp.幻象1长按(time);
		case 8:
			return this.BpInputComp.大招长按(time);
		case 9:
			return this.BpInputComp.幻象2长按(time);
		case 10:
			return this.BpInputComp.切换角色1长按(time);
		case 11:
			return this.BpInputComp.切换角色2长按(time);
		case 12:
			return this.BpInputComp.切换角色3长按(time);
		case 13:
			return this.BpInputComp.锁定目标长按(time);
		case 14:
			return this.BpInputComp.瞄准长按(time);
		default:
			return null;
		}
	}

	// Token: 0x06019ABE RID: 105150 RVA: 0x00776D50 File Offset: 0x00774F50
	public override void DispatchPressEvent(EInputAction action, float time)
	{
		if (this.BpInputComp == null)
		{
			return;
		}
		switch (action)
		{
		case 1:
			this.BpInputComp.跳跃按下事件(time);
			Singleton<EventSystem>.Instance.EmitWithTarget<EInputAction>(this, EEventName.VehicleInputLayerPress, action);
			return;
		case 2:
			this.BpInputComp.攀爬按下事件(time);
			return;
		case 3:
			this.BpInputComp.走跑切换按下事件(time);
			return;
		case 4:
			this.BpInputComp.攻击按下事件(time);
			return;
		case 5:
			this.BpInputComp.闪避按下事件(time);
			return;
		case 6:
			this.BpInputComp.技能1按下事件(time);
			return;
		case 7:
			this.BpInputComp.幻象1按下事件(time);
			return;
		case 8:
			this.BpInputComp.大招按下事件(time);
			return;
		case 9:
			this.BpInputComp.幻象2按下事件(time);
			return;
		case 10:
			this.BpInputComp.切换角色1按下事件(time);
			return;
		case 11:
			this.BpInputComp.切换角色2按下事件(time);
			return;
		case 12:
			this.BpInputComp.切换角色3按下事件(time);
			return;
		case 13:
			this.BpInputComp.锁定目标按下事件(time);
			return;
		case 14:
			this.BpInputComp.瞄准按下事件(time);
			return;
		default:
			return;
		}
	}

	// Token: 0x06019ABF RID: 105151 RVA: 0x00776E78 File Offset: 0x00775078
	public override void DispatchReleaseEvent(EInputAction action, float time)
	{
		if (this.BpInputComp == null)
		{
			return;
		}
		switch (action)
		{
		case 1:
			this.BpInputComp.跳跃抬起事件(time);
			Singleton<EventSystem>.Instance.EmitWithTarget<EInputAction>(this, EEventName.VehicleInputLayerRelease, action);
			return;
		case 2:
			this.BpInputComp.攀爬抬起事件(time);
			return;
		case 3:
			this.BpInputComp.走跑切换抬起事件(time);
			return;
		case 4:
			this.BpInputComp.攻击抬起事件(time);
			return;
		case 5:
			this.BpInputComp.闪避抬起事件(time);
			return;
		case 6:
			this.BpInputComp.技能1抬起事件(time);
			return;
		case 7:
			this.BpInputComp.幻象1抬起事件(time);
			return;
		case 8:
			this.BpInputComp.大招抬起事件(time);
			return;
		case 9:
			this.BpInputComp.幻象2抬起事件(time);
			return;
		case 10:
			this.BpInputComp.切换角色1抬起事件(time);
			return;
		case 11:
			this.BpInputComp.切换角色2抬起事件(time);
			return;
		case 12:
			this.BpInputComp.切换角色3抬起事件(time);
			return;
		case 13:
			this.BpInputComp.锁定目标抬起事件(time);
			return;
		case 14:
			this.BpInputComp.瞄准抬起事件(time);
			return;
		default:
			return;
		}
	}

	// Token: 0x06019AC0 RID: 105152 RVA: 0x00776F9D File Offset: 0x0077519D
	public BP_InputBase_C GetBpInputComp()
	{
		return this.BpInputComp;
	}

	// Token: 0x06019AC1 RID: 105153 RVA: 0x00776FA5 File Offset: 0x007751A5
	public void SetBpInputComp(BP_InputBase_C bpInputComp)
	{
		this.BpInputComp = bpInputComp;
	}

	// Token: 0x06019AC2 RID: 105154 RVA: 0x00776FAE File Offset: 0x007751AE
	public void ResetBpInputComp()
	{
		this.BpInputComp = this.BpInputCompOrigin;
	}

	// Token: 0x0400CC62 RID: 52322
	[Nullable(1)]
	private const string NPC_VEHICLE_INPUT_CLASS_PATH = "/Game/Aki/Character/NPC/BP_InputComponent_NpcVehicle.BP_InputComponent_NpcVehicle_C";

	// Token: 0x0400CC63 RID: 52323
	private BP_InputBase_C BpInputComp;

	// Token: 0x0400CC64 RID: 52324
	private BP_InputBase_C BpInputCompOrigin;
}
