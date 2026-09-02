using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc;
using UnrealEngine;

// Token: 0x02002FB1 RID: 12209
public class GameplayCueMotorcycleAssemble : GameplayCueBase
{
	// Token: 0x06018E62 RID: 101986 RVA: 0x0070D764 File Offset: 0x0070B964
	protected override void OnInit()
	{
		base.OnInit();
		this.Resource = null;
	}

	// Token: 0x06018E63 RID: 101987 RVA: 0x0070D773 File Offset: 0x0070B973
	protected override void OnTick(float delta)
	{
		base.OnTick(delta);
	}

	// Token: 0x06018E64 RID: 101988 RVA: 0x0070D77C File Offset: 0x0070B97C
	protected override void OnCreate()
	{
		base.OnCreate();
		Singleton<ResourceSystem>.Instance.LoadAsync<UObject>(base.GetPath(), delegate([Nullable(2)] UObject res, string _)
		{
			if (!this.IsActive)
			{
				return;
			}
			this.Resource = res;
			this.AddMotorcycleAssemble();
		}, 100, "js_undefined");
	}

	// Token: 0x06018E65 RID: 101989 RVA: 0x0070D7A8 File Offset: 0x0070B9A8
	protected override void OnDestroy()
	{
		base.OnDestroy();
		this.Resource = null;
		this.RemoveMotorcycleAssemble();
	}

	// Token: 0x06018E66 RID: 101990 RVA: 0x0070D7C0 File Offset: 0x0070B9C0
	private unsafe void AddMotorcycleAssemble()
	{
		if (!this.ActorInternal.IsValid() || this.Resource == null)
		{
			return;
		}
		PD_MotorExtraComponentData_C pd_MotorExtraComponentData_C = this.Resource as PD_MotorExtraComponentData_C;
		if (pd_MotorExtraComponentData_C != null)
		{
			base.GetCharRenderingComponent().AddMotorExtraComp(pd_MotorExtraComponentData_C);
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Battle;
		ELogAuthor author = ELogAuthor.GHY;
		string message = "摩托车拼装传入DA类型错误:";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Buff特效Id", this.CueConfig.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("DA路径", this.CueConfig.Path);
		instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x06018E67 RID: 101991 RVA: 0x0070D86C File Offset: 0x0070BA6C
	private void RemoveMotorcycleAssemble()
	{
		CharRenderingComponent charRenderingComponent = base.GetCharRenderingComponent();
		if (charRenderingComponent == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.GHY;
			string message = "RemoveMaterialController CharRenderingComponent为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.CueConfig.Id);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		charRenderingComponent.RemoveMotorExtraComp();
	}

	// Token: 0x0400C28A RID: 49802
	[Nullable(2)]
	private UObject Resource;
}
