using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component
{
	// Token: 0x020048F6 RID: 18678
	public class GameplayCueMotorcycleAssemble : GameplayCueBase
	{
		// Token: 0x06030C59 RID: 199769 RVA: 0x00C0C8D9 File Offset: 0x00C0AAD9
		protected override void OnInit()
		{
			base.OnInit();
			this.Resource = null;
		}

		// Token: 0x06030C5A RID: 199770 RVA: 0x00C0C8E8 File Offset: 0x00C0AAE8
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

		// Token: 0x06030C5B RID: 199771 RVA: 0x00C0C914 File Offset: 0x00C0AB14
		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.Resource = null;
			this.RemoveMotorcycleAssemble();
		}

		// Token: 0x06030C5C RID: 199772 RVA: 0x00C0C92C File Offset: 0x00C0AB2C
		private unsafe void AddMotorcycleAssemble()
		{
			if (this.ActorInternal == null || !this.ActorInternal.IsValid() || this.Resource == null)
			{
				return;
			}
			PD_MotorExtraComponentData_C pd_MotorExtraComponentData_C = this.Resource as PD_MotorExtraComponentData_C;
			if (pd_MotorExtraComponentData_C == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.GHY;
				string message = "摩托车拼装传入DA类型错误:";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Buff特效Id", this.CueConfig.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("DA路径", this.CueConfig.Path);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			CharRenderingComponent charRenderingComponent = base.GetCharRenderingComponent();
			if (charRenderingComponent == null)
			{
				return;
			}
			charRenderingComponent.AddMotorExtraComp(pd_MotorExtraComponentData_C);
		}

		// Token: 0x06030C5D RID: 199773 RVA: 0x00C0C9E4 File Offset: 0x00C0ABE4
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

		// Token: 0x0401C062 RID: 114786
		[Nullable(2)]
		private UObject Resource;
	}
}
