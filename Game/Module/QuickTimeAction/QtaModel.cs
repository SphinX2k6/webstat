using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.QuickTimeAction;
using AkiClient.Game.Aki.Data.QuickTimeAction.Customization;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data;
using CSharpScript.Game.Module.QuickTimeAction.Context;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickTimeAction
{
	// Token: 0x020052B6 RID: 21174
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class QtaModel : ModelBase<QtaModel>
	{
		// Token: 0x060361EB RID: 221675 RVA: 0x00DA0E4D File Offset: 0x00D9F04D
		protected override bool OnInit()
		{
			this.LoadBaseResources().Forget<bool>();
			return true;
		}

		// Token: 0x060361EC RID: 221676 RVA: 0x00DA0E5C File Offset: 0x00D9F05C
		protected override bool OnLeaveLevel()
		{
			this.HandleIdCounter = 0;
			this.ClearPreloadCache(null);
			Dictionary<int, QtaContextBase> contexts = this.Contexts;
			if (contexts != null)
			{
				contexts.Clear();
			}
			return true;
		}

		// Token: 0x060361ED RID: 221677 RVA: 0x00DA0E94 File Offset: 0x00D9F094
		[NullableContext(2)]
		public QtaContextBase CreateQtaContext(int qtaId, TQtaCallback onResult = null, EQtaSource source = EQtaSource.Battle, IQtaExtraParams extraParams = null)
		{
			SQta qtaConfig = this.GetQtaConfig(qtaId);
			if (qtaConfig == null)
			{
				return null;
			}
			if (qtaConfig.BaseConfig.QtaType == 0)
			{
				QtaContextBase qtaContextBase = new QtaCustomizationContext();
				qtaContextBase.QtaId = qtaId;
				qtaContextBase.Source = new EQtaSource?(source);
				QtaContextBase qtaContextBase2 = qtaContextBase;
				int num = this.HandleIdCounter + 1;
				this.HandleIdCounter = num;
				qtaContextBase2.HandleId = num;
				qtaContextBase.ResultCallback = onResult;
				qtaContextBase.ExtraParams = extraParams;
				qtaContextBase.SetConfig(qtaConfig);
				if (extraParams != null && extraParams.IsPendingExternalCompletion.GetValueOrDefault())
				{
					qtaContextBase.EnableExternalConditionMet(EQtaExternalReason.Default);
				}
				return qtaContextBase;
			}
			return null;
		}

		// Token: 0x060361EE RID: 221678 RVA: 0x00DA0F2D File Offset: 0x00D9F12D
		public void SetCurrentQta(QtaContextBase context)
		{
			this.HandleId = context.HandleId;
			if (this.Contexts == null)
			{
				this.Contexts = new Dictionary<int, QtaContextBase>();
			}
			this.Contexts[context.HandleId] = context;
		}

		// Token: 0x060361EF RID: 221679 RVA: 0x00DA0F60 File Offset: 0x00D9F160
		[NullableContext(0)]
		private UniTask<bool> LoadBaseResources()
		{
			QtaModel.<LoadBaseResources>d__14 <LoadBaseResources>d__;
			<LoadBaseResources>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<LoadBaseResources>d__.<>4__this = this;
			<LoadBaseResources>d__.<>1__state = -1;
			<LoadBaseResources>d__.<>t__builder.Start<QtaModel.<LoadBaseResources>d__14>(ref <LoadBaseResources>d__);
			return <LoadBaseResources>d__.<>t__builder.Task;
		}

		// Token: 0x060361F0 RID: 221680 RVA: 0x00DA0FA4 File Offset: 0x00D9F1A4
		[NullableContext(2)]
		public SQta GetQtaConfig(int qtaId)
		{
			SQta result;
			if (this.QtaConfigCache.TryGetValue(qtaId, out result))
			{
				return result;
			}
			SQta dataTableRow = DataTableUtil.GetDataTableRow<SQta>(this.QtaDt, qtaId.ToString());
			if (dataTableRow != null)
			{
				this.QtaConfigCache[qtaId] = dataTableRow;
				return dataTableRow;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.HWR;
			string message = "找不到Qta配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("QtaId", qtaId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}

		// Token: 0x060361F1 RID: 221681 RVA: 0x00DA101B File Offset: 0x00D9F21B
		public int GetQtaHandleId()
		{
			return this.HandleId;
		}

		// Token: 0x060361F2 RID: 221682 RVA: 0x00DA1024 File Offset: 0x00D9F224
		public void ClearQtaHandleId(int? qtaHandleId = null)
		{
			int key = qtaHandleId ?? this.HandleId;
			Dictionary<int, QtaContextBase> contexts = this.Contexts;
			int? num;
			if (contexts == null)
			{
				num = null;
			}
			else
			{
				QtaContextBase valueOrDefault = contexts.GetValueOrDefault(key);
				num = ((valueOrDefault != null) ? new int?(valueOrDefault.QtaId) : null);
			}
			int? num2 = num;
			if (num2.GetValueOrDefault() != 0)
			{
				this.QtaConfigCache.Remove(num2.Value);
				this.QtaPromptResources.Remove(num2.Value);
			}
			this.HandleId = -1;
		}

		// Token: 0x060361F3 RID: 221683 RVA: 0x00DA10B7 File Offset: 0x00D9F2B7
		[NullableContext(2)]
		public QtaContextBase GetQtaContext(int qtaHandleId)
		{
			Dictionary<int, QtaContextBase> contexts = this.Contexts;
			if (contexts == null)
			{
				return null;
			}
			return contexts.GetValueOrDefault(qtaHandleId);
		}

		// Token: 0x060361F4 RID: 221684 RVA: 0x00DA10CC File Offset: 0x00D9F2CC
		public void GetQtaDa(int qtaId, List<string> daPaths)
		{
			SQta qtaConfig = this.GetQtaConfig(qtaId);
			if (qtaConfig == null)
			{
				return;
			}
			if (qtaConfig.BaseConfig.QtaType == EQtaType.定制型 && qtaConfig.BaseConfig.CustomizationConfig.DaConfig != null)
			{
				daPaths.Add(qtaConfig.BaseConfig.CustomizationConfig.DaConfig.ToAssetPathName());
			}
		}

		// Token: 0x060361F5 RID: 221685 RVA: 0x00DA1138 File Offset: 0x00D9F338
		[NullableContext(2)]
		public unsafe string GetQtaItemName(int qtaId)
		{
			SQta qtaConfig = this.GetQtaConfig(qtaId);
			if (qtaConfig == null)
			{
				return null;
			}
			if (qtaConfig.BaseConfig.QtaType == EQtaType.定制型)
			{
				SQtaCustomization customizationConfig = qtaConfig.BaseConfig.CustomizationConfig;
				if (customizationConfig.ViewType == EQtaCustomizationViewType.限次长按洛瑟菈技能交互指示器界面)
				{
					if (customizationConfig.ViewName.Length > 4)
					{
						QtaContextBase qtaContext = null;
						string message = "使用配置指定的ui";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("", customizationConfig.ViewName);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("qtaId", qtaId);
						QtaLog.Info(qtaContext, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
						return customizationConfig.ViewName;
					}
					return "UiItem_CircularLimitedLongPress";
				}
			}
			return null;
		}

		// Token: 0x060361F6 RID: 221686 RVA: 0x00DA1204 File Offset: 0x00D9F404
		public EUiViewName? GetQtaViewName(int qtaId)
		{
			SQta qtaConfig = this.GetQtaConfig(qtaId);
			if (qtaConfig == null)
			{
				return null;
			}
			if (qtaConfig.BaseConfig.QtaType == EQtaType.定制型)
			{
				SQtaCustomization customizationConfig = qtaConfig.BaseConfig.CustomizationConfig;
				if (customizationConfig.ViewType == EQtaCustomizationViewType.拍照并收集物品)
				{
					return new EUiViewName?(EUiViewName.CaptureCollectView);
				}
				if (customizationConfig.ViewType == EQtaCustomizationViewType.打开指定界面 && customizationConfig.ViewName.Length > 4)
				{
					return new EUiViewName?((EUiViewName)customizationConfig.ViewName);
				}
			}
			return null;
		}

		// Token: 0x060361F7 RID: 221687 RVA: 0x00DA12AC File Offset: 0x00D9F4AC
		[NullableContext(2)]
		public IQtaUiResource GetQtaUiResource(int qtaId, bool init = false)
		{
			if (!init)
			{
				return this.QtaUiResources.GetValueOrDefault(qtaId);
			}
			IQtaUiResource qtaUiResource = this.QtaUiResources.GetValueOrDefault(qtaId);
			if (qtaUiResource == null)
			{
				qtaUiResource = new IQtaUiResource();
				this.QtaUiResources[qtaId] = qtaUiResource;
			}
			return qtaUiResource;
		}

		// Token: 0x060361F8 RID: 221688 RVA: 0x00DA12ED File Offset: 0x00D9F4ED
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<int, IQtaPromptResource> GetQtaPromptObj(int qtaId)
		{
			return this.QtaPromptResources.GetValueOrDefault(qtaId);
		}

		// Token: 0x060361F9 RID: 221689 RVA: 0x00DA12FC File Offset: 0x00D9F4FC
		[NullableContext(2)]
		public IQtaPromptResource GetQtaPromptResource(int qtaId, EQtaPromptType px, bool init = false)
		{
			if (init)
			{
				Dictionary<int, IQtaPromptResource> dictionary = this.QtaPromptResources.GetValueOrDefault(qtaId);
				if (dictionary == null)
				{
					dictionary = new Dictionary<int, IQtaPromptResource>();
					this.QtaPromptResources[qtaId] = dictionary;
				}
				IQtaPromptResource qtaPromptResource = dictionary.GetValueOrDefault((int)px);
				if (qtaPromptResource == null)
				{
					qtaPromptResource = new IQtaPromptResource();
					dictionary[(int)px] = qtaPromptResource;
				}
				qtaPromptResource.CueIds = new List<long>();
				return qtaPromptResource;
			}
			Dictionary<int, IQtaPromptResource> valueOrDefault = this.QtaPromptResources.GetValueOrDefault(qtaId);
			if (valueOrDefault == null)
			{
				return null;
			}
			return valueOrDefault.GetValueOrDefault((int)px);
		}

		// Token: 0x060361FA RID: 221690 RVA: 0x00DA1370 File Offset: 0x00D9F570
		[return: Nullable(new byte[]
		{
			1,
			0
		})]
		public List<UniTask<bool>> LoadQtaResource(int qtaId)
		{
			if (this.QtaPromptResources.ContainsKey(qtaId))
			{
				return new List<UniTask<bool>>();
			}
			List<UniTask<bool>> list = new List<UniTask<bool>>();
			this.TryLoadQtaResource(list, qtaId);
			return list;
		}

		// Token: 0x060361FB RID: 221691 RVA: 0x00DA13A0 File Offset: 0x00D9F5A0
		private void TryLoadQtaResource([Nullable(new byte[]
		{
			1,
			0
		})] List<UniTask<bool>> promises, int qtaId)
		{
			QtaModel.<>c__DisplayClass26_0 CS$<>8__locals1 = new QtaModel.<>c__DisplayClass26_0();
			CS$<>8__locals1.promises = promises;
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.qtaId = qtaId;
			SQta qtaConfig = this.GetQtaConfig(CS$<>8__locals1.qtaId);
			if (qtaConfig == null)
			{
				return;
			}
			for (int i = 0; i < qtaConfig.BaseConfig.InputConfig.Num(); i++)
			{
				string text = qtaConfig.BaseConfig.InputConfig.Get(i).Icon.ToAssetPathName();
				if (!string.IsNullOrEmpty(text) && text != "None")
				{
					if (text.Contains("UIEditor"))
					{
						text = text.Replace("UIEditor", "UIResources");
					}
					CS$<>8__locals1.promises.Add(this.LoadUiAssetToCache(CS$<>8__locals1.qtaId, text));
				}
			}
			for (int j = 0; j < qtaConfig.Prompt.Num(); j++)
			{
				SQtaPrompt sqtaPrompt = qtaConfig.Prompt.Get(j);
				if (sqtaPrompt.PromptContent != null)
				{
					QtaModel.<>c__DisplayClass26_1 CS$<>8__locals2 = new QtaModel.<>c__DisplayClass26_1();
					CS$<>8__locals2.CS$<>8__locals1 = CS$<>8__locals1;
					CS$<>8__locals2.px = sqtaPrompt.PromptType;
					IQtaPromptResource qtaPromptResource = this.GetQtaPromptResource(CS$<>8__locals2.CS$<>8__locals1.qtaId, CS$<>8__locals2.px, true);
					if (qtaPromptResource != null)
					{
						qtaPromptResource.Audio = sqtaPrompt.PromptContent.Audio.ToAssetPathName();
						for (int k = 0; k < sqtaPrompt.PromptContent.Cue.Num(); k++)
						{
							long num = sqtaPrompt.PromptContent.Cue.Get(k);
							if (num > 0L)
							{
								qtaPromptResource.CueIds.Add(num);
							}
						}
					}
					string text = sqtaPrompt.PromptContent.ScreenEffectType1.ToAssetPathName();
					if (!string.IsNullOrEmpty(text) && text != "None")
					{
						CS$<>8__locals2.CS$<>8__locals1.promises.Add(this.LoadPromptAssetToCache(CS$<>8__locals2.CS$<>8__locals1.qtaId, (int)CS$<>8__locals2.px, text, EffectScreenPlayData_C.StaticClass().ToUClass()));
					}
					text = sqtaPrompt.PromptContent.ScreenEffectType2.ToAssetPathName();
					if (!string.IsNullOrEmpty(text) && text != "None")
					{
						CS$<>8__locals2.screenEffectPath = text;
						Singleton<ResourceSystem>.Instance.LoadTypeAsync(EBpTypeName.EffectModelPostProcess_C.ToEnumString(), new Action(CS$<>8__locals2.<TryLoadQtaResource>g__LoadEffect|0), "js_undefined");
					}
					text = sqtaPrompt.PromptContent.CameraShake.ToAssetPathName();
					if (!string.IsNullOrEmpty(text) && text != "None")
					{
						CS$<>8__locals2.CS$<>8__locals1.promises.Add(this.LoadPromptAssetToCache(CS$<>8__locals2.CS$<>8__locals1.qtaId, (int)CS$<>8__locals2.px, text, UClass.StaticClass().ToUClass()));
					}
					text = sqtaPrompt.PromptContent.GamepadShake.ToAssetPathName();
					if (!string.IsNullOrEmpty(text) && text != "None")
					{
						CS$<>8__locals2.CS$<>8__locals1.promises.Add(this.LoadPromptAssetToCache(CS$<>8__locals2.CS$<>8__locals1.qtaId, (int)CS$<>8__locals2.px, text, UKuroForceFeedbackEffect.StaticClass().ToUClass()));
					}
				}
			}
			if (qtaConfig.BaseConfig.QtaType == EQtaType.定制型)
			{
				SQtaCustomization customizationConfig = qtaConfig.BaseConfig.CustomizationConfig;
				TSoftObjectPtr<BP_QtaCustomizationBase_C> tsoftObjectPtr = (customizationConfig != null) ? customizationConfig.DaConfig : null;
				if (tsoftObjectPtr != null)
				{
					string text2 = tsoftObjectPtr.ToAssetPathName();
					if (!string.IsNullOrEmpty(text2) && text2 != "None")
					{
						CS$<>8__locals1.promises.Add(this.LoadUiAssetToCache(CS$<>8__locals1.qtaId, text2));
					}
				}
			}
		}

		// Token: 0x060361FC RID: 221692 RVA: 0x00DA1730 File Offset: 0x00D9F930
		[NullableContext(0)]
		private UniTask<bool> LoadUiAssetToCache(int qtaId, [Nullable(1)] string path)
		{
			QtaModel.<LoadUiAssetToCache>d__27 <LoadUiAssetToCache>d__;
			<LoadUiAssetToCache>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<LoadUiAssetToCache>d__.<>4__this = this;
			<LoadUiAssetToCache>d__.qtaId = qtaId;
			<LoadUiAssetToCache>d__.path = path;
			<LoadUiAssetToCache>d__.<>1__state = -1;
			<LoadUiAssetToCache>d__.<>t__builder.Start<QtaModel.<LoadUiAssetToCache>d__27>(ref <LoadUiAssetToCache>d__);
			return <LoadUiAssetToCache>d__.<>t__builder.Task;
		}

		// Token: 0x060361FD RID: 221693 RVA: 0x00DA1784 File Offset: 0x00D9F984
		[return: Nullable(0)]
		private UniTask<bool> LoadPromptAssetToCache(int qtaId, int px, string path, UClass type)
		{
			QtaModel.<LoadPromptAssetToCache>d__28 <LoadPromptAssetToCache>d__;
			<LoadPromptAssetToCache>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<LoadPromptAssetToCache>d__.<>4__this = this;
			<LoadPromptAssetToCache>d__.qtaId = qtaId;
			<LoadPromptAssetToCache>d__.px = px;
			<LoadPromptAssetToCache>d__.path = path;
			<LoadPromptAssetToCache>d__.type = type;
			<LoadPromptAssetToCache>d__.<>1__state = -1;
			<LoadPromptAssetToCache>d__.<>t__builder.Start<QtaModel.<LoadPromptAssetToCache>d__28>(ref <LoadPromptAssetToCache>d__);
			return <LoadPromptAssetToCache>d__.<>t__builder.Task;
		}

		// Token: 0x060361FE RID: 221694 RVA: 0x00DA17E8 File Offset: 0x00D9F9E8
		public void ClearPreloadCache(int? qtaId = null)
		{
			if (qtaId != null)
			{
				this.QtaConfigCache.Remove(qtaId.Value);
				this.QtaUiResources.Remove(qtaId.Value);
				this.QtaPromptResources.Remove(qtaId.Value);
				return;
			}
			this.QtaConfigCache.Clear();
			this.QtaUiResources.Clear();
			this.QtaPromptResources.Clear();
		}

		// Token: 0x0401F17E RID: 127358
		private const string DT_QTA_PATH = "/Game/Aki/Data/QuickTimeAction/DT_Qta.DT_Qta";

		// Token: 0x0401F17F RID: 127359
		private const string UI_EDITOR_PATH = "UIEditor";

		// Token: 0x0401F180 RID: 127360
		private const string UI_RESOURCES_PATH = "UIResources";

		// Token: 0x0401F181 RID: 127361
		private int HandleId = -1;

		// Token: 0x0401F182 RID: 127362
		private int HandleIdCounter;

		// Token: 0x0401F183 RID: 127363
		[Nullable(2)]
		private UDataTable QtaDt;

		// Token: 0x0401F184 RID: 127364
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<int, QtaContextBase> Contexts;

		// Token: 0x0401F185 RID: 127365
		private readonly Dictionary<int, IQtaUiResource> QtaUiResources = new Dictionary<int, IQtaUiResource>();

		// Token: 0x0401F186 RID: 127366
		private readonly Dictionary<int, Dictionary<int, IQtaPromptResource>> QtaPromptResources = new Dictionary<int, Dictionary<int, IQtaPromptResource>>();

		// Token: 0x0401F187 RID: 127367
		private readonly Dictionary<int, SQta> QtaConfigCache = new Dictionary<int, SQta>();
	}
}
