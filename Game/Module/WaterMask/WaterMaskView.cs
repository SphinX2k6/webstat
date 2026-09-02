using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.BaseConfig;
using UnrealEngine;

namespace CSharpScript.Game.Module.WaterMask
{
	// Token: 0x02004C01 RID: 19457
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class WaterMaskView : UiControllerBase<WaterMaskView>
	{
		// Token: 0x06032C70 RID: 207984 RVA: 0x00CB86D8 File Offset: 0x00CB68D8
		public static bool ShouldRegister()
		{
			return Singleton<BaseConfigController>.Instance.GetPackageConfigOrDefault("WaterMask", "false") == "true";
		}

		// Token: 0x06032C71 RID: 207985 RVA: 0x00CB86F8 File Offset: 0x00CB68F8
		public bool CanOpenView()
		{
			return false;
		}

		// Token: 0x06032C72 RID: 207986 RVA: 0x00CB86FC File Offset: 0x00CB68FC
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnGetPlayerBasicInfo, new Action(this.CreateWaterMask));
			Singleton<EventSystem>.Instance.Add(EEventName.SetResolution, new Action(this.ResolutionChange));
			Singleton<EventSystem>.Instance.Add(EEventName.BackLoginView, new Action(this.RemoveWaterMask));
		}

		// Token: 0x06032C73 RID: 207987 RVA: 0x00CB8760 File Offset: 0x00CB6960
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnGetPlayerBasicInfo, new Action(this.CreateWaterMask));
			Singleton<EventSystem>.Instance.Remove(EEventName.SetResolution, new Action(this.ResolutionChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.BackLoginView, new Action(this.RemoveWaterMask));
		}

		// Token: 0x06032C74 RID: 207988 RVA: 0x00CB87C4 File Offset: 0x00CB69C4
		private void CreateWaterMask()
		{
			if (this.ContainerActor != null)
			{
				this.RemoveWaterMask();
			}
			UUIItem layerRootUiItem = Singleton<UiLayer>.Instance.GetLayerRootUiItem(ELayerType.WaterMask);
			this.ContainerActor = UKuroActorManager.D_SpawnActor(Singleton<Info>.Instance.World, AUIContainerActor.StaticClass(), FTransformDouble.Identity, ESpawnActorCollisionHandlingMethod.Undefined, null, null, false);
			UUIItem uuiitem = this.ContainerActor.RootComponent as UUIItem;
			uuiitem.SetDisplayName("WaterMaskContainer");
			UKuroStaticLibrary.SetActorPermanent(this.ContainerActor, true, true);
			this.ContainerActor.K2_AttachRootComponentTo(layerRootUiItem, default(FName), EAttachLocation.KeepRelativeOffset, true);
			UUIItem uuiitem2 = uuiitem.GetRootCanvas().GetOwner().RootComponent as UUIItem;
			float num = uuiitem2.widget.width % 300f / 2f;
			float num2 = uuiitem2.widget.height % 300f / 2f;
			float num3 = uuiitem2.widget.width / 2f;
			float num4 = uuiitem2.widget.height / 2f;
			int num5 = (int)Math.Ceiling((double)(uuiitem2.widget.width / 300f));
			int num6 = (int)Math.Ceiling((double)(uuiitem2.widget.height / 300f));
			string newText = ModelBase<FunctionModel>.Instance.PlayerId.ToString();
			for (int i = 0; i < num5; i++)
			{
				for (int j = 0; j < num6; j++)
				{
					AActor aactor = UKuroActorManager.D_SpawnActor(Singleton<Info>.Instance.World, AUITextActor.StaticClass(), FTransformDouble.Identity, ESpawnActorCollisionHandlingMethod.Undefined, null, null, false);
					UUIItem uuiitem3 = aactor.RootComponent as UUIItem;
					aactor.K2_AttachRootComponentTo(uuiitem, default(FName), EAttachLocation.KeepRelativeOffset, true);
					uuiitem3.SetDisplayName("WaterMaskText");
					UUIText uuitext = aactor.GetComponentByClass(UUIText.StaticClass()) as UUIText;
					uuitext.SetFontSize(40f);
					uuitext.SetOverflowType(UITextOverflowType.HorizontalOverflow);
					uuitext.SetAlpha(0.09f);
					uuitext.SetFont(ULGUIFontData.GetDefaultFont());
					uuitext.SetText(newText, true);
					uuitext.SetUIRelativeLocation(new FVector((float)(i * 300) - num3 + num, (float)(j * 300) - num4 + num2, 0f));
					FRotator frotator = new FRotator(0f, 30f, 0f);
					uuitext.SetUIRelativeRotation(frotator);
					UKuroStaticLibrary.SetActorPermanent(aactor, true, true);
				}
			}
		}

		// Token: 0x06032C75 RID: 207989 RVA: 0x00CB8A1D File Offset: 0x00CB6C1D
		private void RemoveWaterMask()
		{
			if (this.ContainerActor != null)
			{
				this.ContainerActor.K2_DestroyActor();
				this.ContainerActor = null;
			}
		}

		// Token: 0x06032C76 RID: 207990 RVA: 0x00CB8A39 File Offset: 0x00CB6C39
		private void ResolutionChange()
		{
			this.RemoveWaterMask();
			this.CreateWaterMask();
		}

		// Token: 0x0401D8B5 RID: 121013
		private AActor ContainerActor;

		// Token: 0x0401D8B6 RID: 121014
		private const int ColSpace = 300;

		// Token: 0x0401D8B7 RID: 121015
		private const int RowSpace = 300;

		// Token: 0x0401D8B8 RID: 121016
		private const float TextRotation = 30f;

		// Token: 0x0401D8B9 RID: 121017
		private const float TextAlpha = 0.09f;

		// Token: 0x0401D8BA RID: 121018
		private const int FontSize = 40;
	}
}
