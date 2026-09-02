using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.QuickTimeAction;
using AkiClient.Game.Aki.Data.QuickTimeAction.Customization;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickTimeAction.Context
{
	// Token: 0x020052C1 RID: 21185
	[NullableContext(2)]
	[Nullable(0)]
	public class QtaCustomizationContext : QtaContextBase
	{
		// Token: 0x0603628D RID: 221837 RVA: 0x00DA3D29 File Offset: 0x00DA1F29
		public QtaCustomizationContext()
		{
			this.Type = new EQtaContextType?(EQtaContextType.Customization);
		}

		// Token: 0x17008CFF RID: 36095
		// (get) Token: 0x0603628E RID: 221838 RVA: 0x00DA3D3D File Offset: 0x00DA1F3D
		public bool IsInited
		{
			get
			{
				return this.Inited;
			}
		}

		// Token: 0x17008D00 RID: 36096
		// (get) Token: 0x0603628F RID: 221839 RVA: 0x00DA3D45 File Offset: 0x00DA1F45
		public QtaCustomizationBaseLogic QtaCustomizationLogic
		{
			get
			{
				if (this.QtaCzLogic == null)
				{
					return null;
				}
				return this.QtaCzLogic;
			}
		}

		// Token: 0x06036290 RID: 221840 RVA: 0x00DA3D57 File Offset: 0x00DA1F57
		[NullableContext(1)]
		protected override void OnSetConfig(SQta config)
		{
			this.QtaConfig = config;
		}

		// Token: 0x06036291 RID: 221841 RVA: 0x00DA3D60 File Offset: 0x00DA1F60
		public override void OnResourceReady()
		{
			SQta qtaConfig = this.QtaConfig;
			if (qtaConfig == null)
			{
				QtaLog.Error(this, "Qta定制型：缺少配置", default(ReadOnlySpan<ValueTuple<string, object>>));
				ControllerBase<QtaController>.Instance.StopCurrentQta();
				return;
			}
			if (qtaConfig.BaseConfig.QtaType != EQtaType.定制型)
			{
				QtaLog.Error(this, "Qta定制型：传入的类型不正确", default(ReadOnlySpan<ValueTuple<string, object>>));
				ControllerBase<QtaController>.Instance.StopCurrentQta();
				return;
			}
			TSoftObjectPtr<BP_QtaCustomizationBase_C> daConfig = qtaConfig.BaseConfig.CustomizationConfig.DaConfig;
			if (!daConfig.IsValid())
			{
				QtaLog.Error(this, "Qta定制型：缺少DA配置", default(ReadOnlySpan<ValueTuple<string, object>>));
				ControllerBase<QtaController>.Instance.StopCurrentQta();
				return;
			}
			BP_QtaCustomizationBase_C loadedAsset = Singleton<ResourceSystem>.Instance.GetLoadedAsset<BP_QtaCustomizationBase_C>(daConfig.ToAssetPathName());
			if (loadedAsset == null)
			{
				string message = "Qta定制型：DA未加载或类型不正确";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("", daConfig.ToAssetPathName());
				QtaLog.Error(this, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				ControllerBase<QtaController>.Instance.StopCurrentQta();
				return;
			}
			if (loadedAsset is BP_QtaCustomization_LimitedHold_C)
			{
				this.QtaCzLogic = new QtaCustomizationLimitedHoldLogic();
			}
			else if (loadedAsset != null)
			{
				this.QtaCzLogic = new QtaCustomizationNull();
			}
			if (this.QtaCzLogic == null)
			{
				QtaLog.Error(this, "Qta定制型：未正确初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
				ControllerBase<QtaController>.Instance.StopCurrentQta();
				return;
			}
			this.QtaCzLogic.OnSetConfig(this, qtaConfig, loadedAsset);
			this.QtaCzLogic.OnQtaStart();
			this.Inited = true;
			QtaLog.Info(this, "Qta定制型：成功初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06036292 RID: 221842 RVA: 0x00DA3ED1 File Offset: 0x00DA20D1
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		protected override List<string> OnGetActions()
		{
			QtaCustomizationBaseLogic qtaCzLogic = this.QtaCzLogic;
			if (qtaCzLogic == null)
			{
				return null;
			}
			return qtaCzLogic.OnGetActions();
		}

		// Token: 0x06036293 RID: 221843 RVA: 0x00DA3EE4 File Offset: 0x00DA20E4
		protected override void OnQtaResponse(bool press)
		{
			QtaCustomizationBaseLogic qtaCzLogic = this.QtaCzLogic;
			if (qtaCzLogic == null)
			{
				return;
			}
			qtaCzLogic.OnQtaResponse(press);
		}

		// Token: 0x06036294 RID: 221844 RVA: 0x00DA3EF7 File Offset: 0x00DA20F7
		protected override void OnUpdateTime(float delta)
		{
			QtaCustomizationBaseLogic qtaCzLogic = this.QtaCzLogic;
			if (qtaCzLogic == null)
			{
				return;
			}
			qtaCzLogic.OnUpdateTime(delta);
		}

		// Token: 0x06036295 RID: 221845 RVA: 0x00DA3F0A File Offset: 0x00DA210A
		public override float GetProgress()
		{
			QtaCustomizationBaseLogic qtaCzLogic = this.QtaCzLogic;
			if (qtaCzLogic == null)
			{
				return 0f;
			}
			return qtaCzLogic.GetProgress();
		}

		// Token: 0x06036296 RID: 221846 RVA: 0x00DA3F21 File Offset: 0x00DA2121
		protected override bool CheckQtaCanEnd()
		{
			QtaCustomizationBaseLogic qtaCzLogic = this.QtaCzLogic;
			return qtaCzLogic != null && qtaCzLogic.CheckQtaCanEnd();
		}

		// Token: 0x06036297 RID: 221847 RVA: 0x00DA3F34 File Offset: 0x00DA2134
		public override void OnPreEndQta()
		{
			QtaCustomizationBaseLogic qtaCzLogic = this.QtaCzLogic;
			if (qtaCzLogic == null)
			{
				return;
			}
			qtaCzLogic.OnPreEndQta();
		}

		// Token: 0x06036298 RID: 221848 RVA: 0x00DA3F46 File Offset: 0x00DA2146
		protected override void OnQtaResult(EQtaResult qtaResult)
		{
			QtaCustomizationBaseLogic qtaCzLogic = this.QtaCzLogic;
			if (qtaCzLogic == null)
			{
				return;
			}
			qtaCzLogic.OnQtaEnd(qtaResult == EQtaResult.Success);
		}

		// Token: 0x0401F1D4 RID: 127444
		private SQta QtaConfig;

		// Token: 0x0401F1D5 RID: 127445
		private QtaCustomizationBaseLogic QtaCzLogic;

		// Token: 0x0401F1D6 RID: 127446
		private bool Inited;
	}
}
