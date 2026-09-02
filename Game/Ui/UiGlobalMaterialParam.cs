using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A45 RID: 19013
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class UiGlobalMaterialParam : Singleton<UiGlobalMaterialParam>
	{
		// Token: 0x06031AB0 RID: 203440 RVA: 0x00C60068 File Offset: 0x00C5E268
		public UniTask InitAsync()
		{
			UiGlobalMaterialParam.<InitAsync>d__2 <InitAsync>d__;
			<InitAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitAsync>d__.<>4__this = this;
			<InitAsync>d__.<>1__state = -1;
			<InitAsync>d__.<>t__builder.Start<UiGlobalMaterialParam.<InitAsync>d__2>(ref <InitAsync>d__);
			return <InitAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031AB1 RID: 203441 RVA: 0x00C600AB File Offset: 0x00C5E2AB
		public void Refresh()
		{
			this.ResetLguiWidth();
		}

		// Token: 0x06031AB2 RID: 203442 RVA: 0x00C600B3 File Offset: 0x00C5E2B3
		public void Clear()
		{
			Singleton<Application>.Instance.RemoveApplicationHandler(EApplicationLifetimeDelegate.ApplicationHasReactivatedDelegate, new Action(this.AppEnterForeground));
		}

		// Token: 0x06031AB3 RID: 203443 RVA: 0x00C600CC File Offset: 0x00C5E2CC
		private void AppEnterForeground()
		{
			this.ResetLguiWidth();
		}

		// Token: 0x06031AB4 RID: 203444 RVA: 0x00C600D4 File Offset: 0x00C5E2D4
		private void ResetLguiWidth()
		{
			UMaterialParameterCollection collection = new UMaterialParameterCollection();
			BP_CharacterRenderingFunctionLibrary_C.StaticClass();
			BP_CharacterRenderingFunctionLibrary_C.GetLGUIMPC(Singleton<UiLayer>.Instance.UiRoot, ref collection);
			UKismetMaterialLibrary.SetScalarParameterValue(Singleton<UiLayer>.Instance.UiRoot.GetWorld(), collection, this.LguiWidth, Singleton<UiLayer>.Instance.UiRootItem.GetWidth());
			UKismetMaterialLibrary.SetScalarParameterValue(Singleton<UiLayer>.Instance.UiRoot.GetWorld(), collection, this.LguiRenderOnScreen, 1f);
		}

		// Token: 0x0401CE83 RID: 118403
		public FName LguiWidth = new FName("LGUIWidth");

		// Token: 0x0401CE84 RID: 118404
		public FName LguiRenderOnScreen = new FName("RenderOnScreenWPO");
	}
}
