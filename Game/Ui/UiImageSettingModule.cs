using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Skin;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A46 RID: 19014
	[NullableContext(1)]
	[Nullable(0)]
	public class UiImageSettingModule : UiResourceLoadModule
	{
		// Token: 0x06031AB6 RID: 203446 RVA: 0x00C60170 File Offset: 0x00C5E370
		private void SetSpriteBySprite([Nullable(2)] ULGUISpriteData_BaseObject sprite, UUISprite uiSprite, bool setSize, string path, [Nullable(2)] Action<bool> callback = null)
		{
			if (!uiSprite.IsValid())
			{
				return;
			}
			if (sprite == null || !sprite.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiImageSetting;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "设置Sprite失败，图片加载失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("图片路径", path);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				if (callback != null)
				{
					callback(false);
				}
				return;
			}
			uiSprite.SetSprite(sprite, setSize);
			if (callback != null)
			{
				callback(true);
			}
		}

		// Token: 0x06031AB7 RID: 203447 RVA: 0x00C601DD File Offset: 0x00C5E3DD
		private void SetSpriteTransitionBySprite([Nullable(2)] ULGUISpriteData_BaseObject sprite, UUISpriteTransition uiSpriteTransition, EUISelectableSelectionState state = EUISelectableSelectionState.EUISelectableSelectionState_MAX)
		{
			if (!uiSpriteTransition.IsValid())
			{
				return;
			}
			if (state == EUISelectableSelectionState.EUISelectableSelectionState_MAX)
			{
				uiSpriteTransition.SetAllTransitionSprite(sprite);
				return;
			}
			uiSpriteTransition.SetStateSprite(state, sprite);
		}

		// Token: 0x06031AB8 RID: 203448 RVA: 0x00C601FC File Offset: 0x00C5E3FC
		[NullableContext(2)]
		public void SetSpriteByPathSync([Nullable(1)] string path, UUISprite uiSprite, bool setSize, EUiViewName viewName, Action<bool> callback = null)
		{
			if (GlobalData.World == null)
			{
				return;
			}
			if (uiSprite == null || !uiSprite.IsValid())
			{
				return;
			}
			UiViewInfo uiViewInfo = Singleton<UiConfig>.Instance.TryGetViewInfo(viewName);
			if (uiViewInfo == null || uiViewInfo.LoadAsync)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiImageSetting;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "该界面不允许同步加载,Sprite改为异步加载";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", viewName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.SetSpriteByPathAsync(path, uiSprite, setSize, callback);
				return;
			}
			ULGUISpriteData_BaseObject ulguispriteData_BaseObject = this.TryGetSpriteFromAtlasManager(path);
			if (ulguispriteData_BaseObject == null)
			{
				ulguispriteData_BaseObject = Singleton<ResourceSystem>.Instance.Load<ULGUISpriteData_BaseObject>(path, "js_undefined");
			}
			if (ulguispriteData_BaseObject == null || !ulguispriteData_BaseObject.IsValid())
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.UiImageSetting;
				ELogAuthor author2 = ELogAuthor.XXJ;
				string message2 = "设置Sprite失败，图片加载失败";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("图片路径", path);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			uiSprite.SetSprite(ulguispriteData_BaseObject, setSize);
		}

		// Token: 0x06031AB9 RID: 203449 RVA: 0x00C602CC File Offset: 0x00C5E4CC
		[NullableContext(2)]
		public void SetSpriteByPathAsync([Nullable(1)] string path, UUISprite uiSprite, bool setSize, Action<bool> callback = null)
		{
			if (GlobalData.World == null)
			{
				return;
			}
			if (uiSprite == null || !uiSprite.IsValid())
			{
				return;
			}
			base.CancelResource(uiSprite);
			ULGUISpriteData_BaseObject ulguispriteData_BaseObject = this.TryGetSpriteFromAtlasManager(path);
			if (ulguispriteData_BaseObject != null)
			{
				this.SetSpriteBySprite(ulguispriteData_BaseObject, uiSprite, setSize, path, callback);
				return;
			}
			int resourceId = Singleton<ResourceSystem>.Instance.LoadAsync<ULGUISpriteData_BaseObject>(path, delegate([Nullable(2)] ULGUISpriteData_BaseObject image, string loadPath)
			{
				this.DeleteResourceHandle(uiSprite);
				this.SetSpriteBySprite(image, uiSprite, setSize, loadPath, callback);
			}, 102, "js_undefined");
			base.SetResourceId(uiSprite, resourceId);
		}

		// Token: 0x06031ABA RID: 203450 RVA: 0x00C60378 File Offset: 0x00C5E578
		public UniTask SetSpriteAsync(string path, [Nullable(2)] UUISprite uiSprite, bool setSize)
		{
			UiImageSettingModule.<SetSpriteAsync>d__4 <SetSpriteAsync>d__;
			<SetSpriteAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetSpriteAsync>d__.<>4__this = this;
			<SetSpriteAsync>d__.path = path;
			<SetSpriteAsync>d__.uiSprite = uiSprite;
			<SetSpriteAsync>d__.setSize = setSize;
			<SetSpriteAsync>d__.<>1__state = -1;
			<SetSpriteAsync>d__.<>t__builder.Start<UiImageSettingModule.<SetSpriteAsync>d__4>(ref <SetSpriteAsync>d__);
			return <SetSpriteAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031ABB RID: 203451 RVA: 0x00C603D4 File Offset: 0x00C5E5D4
		public UniTask SetSpriteTransitionByPath(string path, [Nullable(2)] UUISpriteTransition uiSpriteTransition, EUISelectableSelectionState state = EUISelectableSelectionState.EUISelectableSelectionState_MAX)
		{
			UiImageSettingModule.<SetSpriteTransitionByPath>d__5 <SetSpriteTransitionByPath>d__;
			<SetSpriteTransitionByPath>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetSpriteTransitionByPath>d__.<>4__this = this;
			<SetSpriteTransitionByPath>d__.path = path;
			<SetSpriteTransitionByPath>d__.uiSpriteTransition = uiSpriteTransition;
			<SetSpriteTransitionByPath>d__.state = state;
			<SetSpriteTransitionByPath>d__.<>1__state = -1;
			<SetSpriteTransitionByPath>d__.<>t__builder.Start<UiImageSettingModule.<SetSpriteTransitionByPath>d__5>(ref <SetSpriteTransitionByPath>d__);
			return <SetSpriteTransitionByPath>d__.<>t__builder.Task;
		}

		// Token: 0x06031ABC RID: 203452 RVA: 0x00C60430 File Offset: 0x00C5E630
		public void SetItemQualityIconSync(UUISprite sprite, int itemId, EUiViewName viewName, CommonDefine.EQualityIconType type = CommonDefine.EQualityIconType.BackgroundSprite, [Nullable(2)] Action<bool> action = null)
		{
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
			this.SetQualityIconByIdSync(sprite, itemConfigData.QualityId, viewName, type, action);
		}

		// Token: 0x06031ABD RID: 203453 RVA: 0x00C6045C File Offset: 0x00C5E65C
		public void SetItemQualityIconAsync(UUISprite sprite, int itemId, CommonDefine.EQualityIconType type = CommonDefine.EQualityIconType.BackgroundSprite, [Nullable(2)] Action<bool> action = null)
		{
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
			if (itemConfigData != null)
			{
				this.SetQualityIconByIdAsync(sprite, itemConfigData.QualityId, type, action);
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiImageSetting;
			ELogAuthor author = ELogAuthor.LRX;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(52, 1);
			defaultInterpolatedStringHandler.AppendLiteral("GetItemConfigData with ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(itemId);
			defaultInterpolatedStringHandler.AppendLiteral(" results in null config data!");
			instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06031ABE RID: 203454 RVA: 0x00C604D4 File Offset: 0x00C5E6D4
		private string GetQualityPath(UUISprite sprite, int qualityId, CommonDefine.EQualityIconType type)
		{
			QualityInfo? itemQualityById = ConfigBase<CommonConfig>.Instance.GetItemQualityById(qualityId);
			TArray<FName> componentTags = sprite.ComponentTags;
			if (componentTags.Num() == 0)
			{
				return ConfigBase<CommonConfig>.Instance.GetItemQualityValueByParam(itemQualityById, new CommonDefine.EQualityIconType?(type)) ?? "";
			}
			string text = componentTags.Get(0).ToString();
			string qualityConfigParam = ConfigBase<ComponentConfig>.Instance.GetQualityConfigParam(text);
			string text2 = null;
			CommonDefine.EQualityIconType value;
			if (qualityConfigParam != null && Enum.TryParse<CommonDefine.EQualityIconType>(qualityConfigParam, true, out value))
			{
				text2 = ConfigBase<CommonConfig>.Instance.GetItemQualityValueByParam(itemQualityById, new CommonDefine.EQualityIconType?(value));
			}
			if (text2 == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiImageSetting;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "配置的表格字段查询到的资源路径不是字符串类型";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("配置的表格字段", text);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return "";
			}
			return text2;
		}

		// Token: 0x06031ABF RID: 203455 RVA: 0x00C6059C File Offset: 0x00C5E79C
		public void SetQualityIconByIdSync(UUISprite sprite, int qualityId, EUiViewName viewName, CommonDefine.EQualityIconType type = CommonDefine.EQualityIconType.BackgroundSprite, [Nullable(2)] Action<bool> action = null)
		{
			string qualityPath = this.GetQualityPath(sprite, qualityId, type);
			this.SetSpriteByPathSync(qualityPath, sprite, false, viewName, action);
		}

		// Token: 0x06031AC0 RID: 203456 RVA: 0x00C605C0 File Offset: 0x00C5E7C0
		public void SetQualityIconByIdAsync(UUISprite sprite, int qualityId, CommonDefine.EQualityIconType type = CommonDefine.EQualityIconType.BackgroundSprite, [Nullable(2)] Action<bool> action = null)
		{
			string qualityPath = this.GetQualityPath(sprite, qualityId, type);
			this.SetSpriteByPathAsync(qualityPath, sprite, false, action);
		}

		// Token: 0x06031AC1 RID: 203457 RVA: 0x00C605E4 File Offset: 0x00C5E7E4
		[NullableContext(2)]
		public void SetTextureByPathSync([Nullable(1)] string path, UUITexture uiTexture, EUiViewName viewName, Action<bool> callback = null)
		{
			if (GlobalData.World == null)
			{
				return;
			}
			if (uiTexture == null || !uiTexture.IsValid())
			{
				return;
			}
			UiViewInfo uiViewInfo = Singleton<UiConfig>.Instance.TryGetViewInfo(viewName);
			if (uiViewInfo == null || !uiViewInfo.LoadAsync)
			{
				UTexture utexture = Singleton<ResourceSystem>.Instance.Load<UTexture>(path, "js_undefined");
				if (utexture != null)
				{
					uiTexture.SetTexture(utexture);
					return;
				}
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiImageSetting;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "该界面不允许同步加载,Texture改为异步加载";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", viewName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.SetTextureByPathAsync(path, uiTexture, callback);
			}
		}

		// Token: 0x06031AC2 RID: 203458 RVA: 0x00C60674 File Offset: 0x00C5E874
		[NullableContext(2)]
		public void SetTextureByPathAsync([Nullable(1)] string path, UUITexture uiTexture, Action<bool> callback = null)
		{
			if (GlobalData.World == null)
			{
				return;
			}
			if (uiTexture == null || !uiTexture.IsValid())
			{
				return;
			}
			base.CancelResource(uiTexture);
			int resourceId = Singleton<ResourceSystem>.Instance.LoadAsync<UTexture>(path2, delegate([Nullable(2)] UTexture image, string path)
			{
				this.DeleteResourceHandle(uiTexture);
				if (!uiTexture.IsValid())
				{
					return;
				}
				if (image == null || !image.IsValid())
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.UiImageSetting;
					ELogAuthor author = ELogAuthor.XXJ;
					string message = "设置Texture失败，图片加载失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("图片路径", path);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					Action<bool> callback2 = callback;
					if (callback2 == null)
					{
						return;
					}
					callback2(false);
					return;
				}
				else
				{
					uiTexture.SetTexture(image);
					Action<bool> callback3 = callback;
					if (callback3 == null)
					{
						return;
					}
					callback3(true);
					return;
				}
			}, 102, "js_undefined");
			base.SetResourceId(uiTexture, resourceId);
		}

		// Token: 0x06031AC3 RID: 203459 RVA: 0x00C606F4 File Offset: 0x00C5E8F4
		public UniTask SetTextureAsync(string path, [Nullable(2)] UUITexture uiTexture)
		{
			UiImageSettingModule.<SetTextureAsync>d__13 <SetTextureAsync>d__;
			<SetTextureAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetTextureAsync>d__.<>4__this = this;
			<SetTextureAsync>d__.path = path;
			<SetTextureAsync>d__.uiTexture = uiTexture;
			<SetTextureAsync>d__.<>1__state = -1;
			<SetTextureAsync>d__.<>t__builder.Start<UiImageSettingModule.<SetTextureAsync>d__13>(ref <SetTextureAsync>d__);
			return <SetTextureAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031AC4 RID: 203460 RVA: 0x00C60748 File Offset: 0x00C5E948
		public UniTask SetTextureTransitionByPath(string path, [Nullable(2)] UUITextureTransitionComponent uiTextureTransition, EUISelectableSelectionState state = EUISelectableSelectionState.EUISelectableSelectionState_MAX)
		{
			UiImageSettingModule.<SetTextureTransitionByPath>d__14 <SetTextureTransitionByPath>d__;
			<SetTextureTransitionByPath>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetTextureTransitionByPath>d__.<>4__this = this;
			<SetTextureTransitionByPath>d__.path = path;
			<SetTextureTransitionByPath>d__.uiTextureTransition = uiTextureTransition;
			<SetTextureTransitionByPath>d__.state = state;
			<SetTextureTransitionByPath>d__.<>1__state = -1;
			<SetTextureTransitionByPath>d__.<>t__builder.Start<UiImageSettingModule.<SetTextureTransitionByPath>d__14>(ref <SetTextureTransitionByPath>d__);
			return <SetTextureTransitionByPath>d__.<>t__builder.Task;
		}

		// Token: 0x06031AC5 RID: 203461 RVA: 0x00C607A4 File Offset: 0x00C5E9A4
		public UniTask SetExtendToggleTextureTransitionByPath(string path, [Nullable(2)] UUIExtendToggleTextureTransition uiExtendToggleTextureTransition, EToggleTransitionState state = EToggleTransitionState.ETT_MAX)
		{
			UiImageSettingModule.<SetExtendToggleTextureTransitionByPath>d__15 <SetExtendToggleTextureTransitionByPath>d__;
			<SetExtendToggleTextureTransitionByPath>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetExtendToggleTextureTransitionByPath>d__.<>4__this = this;
			<SetExtendToggleTextureTransitionByPath>d__.path = path;
			<SetExtendToggleTextureTransitionByPath>d__.uiExtendToggleTextureTransition = uiExtendToggleTextureTransition;
			<SetExtendToggleTextureTransitionByPath>d__.state = state;
			<SetExtendToggleTextureTransitionByPath>d__.<>1__state = -1;
			<SetExtendToggleTextureTransitionByPath>d__.<>t__builder.Start<UiImageSettingModule.<SetExtendToggleTextureTransitionByPath>d__15>(ref <SetExtendToggleTextureTransitionByPath>d__);
			return <SetExtendToggleTextureTransitionByPath>d__.<>t__builder.Task;
		}

		// Token: 0x06031AC6 RID: 203462 RVA: 0x00C60800 File Offset: 0x00C5EA00
		public UniTask SetExtendToggleTextureTransitionGroupByPath(string path, [Nullable(2)] UUIExtendToggleTextureTransition uiExtendToggleTextureTransition, EToggleTransitionState[] states)
		{
			UiImageSettingModule.<SetExtendToggleTextureTransitionGroupByPath>d__16 <SetExtendToggleTextureTransitionGroupByPath>d__;
			<SetExtendToggleTextureTransitionGroupByPath>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetExtendToggleTextureTransitionGroupByPath>d__.<>4__this = this;
			<SetExtendToggleTextureTransitionGroupByPath>d__.path = path;
			<SetExtendToggleTextureTransitionGroupByPath>d__.uiExtendToggleTextureTransition = uiExtendToggleTextureTransition;
			<SetExtendToggleTextureTransitionGroupByPath>d__.states = states;
			<SetExtendToggleTextureTransitionGroupByPath>d__.<>1__state = -1;
			<SetExtendToggleTextureTransitionGroupByPath>d__.<>t__builder.Start<UiImageSettingModule.<SetExtendToggleTextureTransitionGroupByPath>d__16>(ref <SetExtendToggleTextureTransitionGroupByPath>d__);
			return <SetExtendToggleTextureTransitionGroupByPath>d__.<>t__builder.Task;
		}

		// Token: 0x06031AC7 RID: 203463 RVA: 0x00C6085C File Offset: 0x00C5EA5C
		public UniTask SetTextureCustomMaterialAsync(string materialPath, [Nullable(2)] UUITexture uiTexture)
		{
			UiImageSettingModule.<SetTextureCustomMaterialAsync>d__17 <SetTextureCustomMaterialAsync>d__;
			<SetTextureCustomMaterialAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetTextureCustomMaterialAsync>d__.<>4__this = this;
			<SetTextureCustomMaterialAsync>d__.materialPath = materialPath;
			<SetTextureCustomMaterialAsync>d__.uiTexture = uiTexture;
			<SetTextureCustomMaterialAsync>d__.<>1__state = -1;
			<SetTextureCustomMaterialAsync>d__.<>t__builder.Start<UiImageSettingModule.<SetTextureCustomMaterialAsync>d__17>(ref <SetTextureCustomMaterialAsync>d__);
			return <SetTextureCustomMaterialAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031AC8 RID: 203464 RVA: 0x00C608AF File Offset: 0x00C5EAAF
		[NullableContext(2)]
		private void SetExtendToggleSpriteTransitionBySprite(ULGUISpriteData_BaseObject sprite, UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition, EToggleTransitionState state = EToggleTransitionState.ETT_MAX)
		{
			if (uiExtendToggleSpriteTransition == null || !uiExtendToggleSpriteTransition.IsValid())
			{
				return;
			}
			if (state == EToggleTransitionState.ETT_MAX)
			{
				uiExtendToggleSpriteTransition.SetAllStateSprite(sprite);
				return;
			}
			uiExtendToggleSpriteTransition.SetStateSprite(state, sprite, false);
		}

		// Token: 0x06031AC9 RID: 203465 RVA: 0x00C608D4 File Offset: 0x00C5EAD4
		public UniTask SetExtendToggleSpriteTransitionByPath(string path, [Nullable(2)] UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition, EToggleTransitionState[] stateList)
		{
			UiImageSettingModule.<SetExtendToggleSpriteTransitionByPath>d__19 <SetExtendToggleSpriteTransitionByPath>d__;
			<SetExtendToggleSpriteTransitionByPath>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetExtendToggleSpriteTransitionByPath>d__.<>4__this = this;
			<SetExtendToggleSpriteTransitionByPath>d__.path = path;
			<SetExtendToggleSpriteTransitionByPath>d__.uiExtendToggleSpriteTransition = uiExtendToggleSpriteTransition;
			<SetExtendToggleSpriteTransitionByPath>d__.stateList = stateList;
			<SetExtendToggleSpriteTransitionByPath>d__.<>1__state = -1;
			<SetExtendToggleSpriteTransitionByPath>d__.<>t__builder.Start<UiImageSettingModule.<SetExtendToggleSpriteTransitionByPath>d__19>(ref <SetExtendToggleSpriteTransitionByPath>d__);
			return <SetExtendToggleSpriteTransitionByPath>d__.<>t__builder.Task;
		}

		// Token: 0x06031ACA RID: 203466 RVA: 0x00C60930 File Offset: 0x00C5EB30
		private string GetItemIcon(UUITexture texture, int itemId)
		{
			if (itemId == 0)
			{
				return string.Empty;
			}
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
			TArray<FName> componentTags = texture.ComponentTags;
			if (componentTags.Num() == 0)
			{
				return itemConfigData.Icon;
			}
			string tag = componentTags.Get(0).ToString();
			string itemConfigParam = ConfigBase<ComponentConfig>.Instance.GetItemConfigParam(tag);
			return ConfigBase<InventoryConfig>.Instance.GetItemConfigValueByParam(itemId, itemConfigParam, tag) ?? "";
		}

		// Token: 0x06031ACB RID: 203467 RVA: 0x00C609A4 File Offset: 0x00C5EBA4
		public void SetItemIconSync(UUITexture texture, int itemId, EUiViewName viewName, [Nullable(2)] Action<bool> action = null)
		{
			string itemIcon = this.GetItemIcon(texture, itemId);
			if (!string.IsNullOrEmpty(itemIcon))
			{
				this.SetTextureByPathSync(itemIcon, texture, viewName, action);
			}
		}

		// Token: 0x06031ACC RID: 203468 RVA: 0x00C609D0 File Offset: 0x00C5EBD0
		public void SetItemIconAsync(UUITexture texture, int itemId, [Nullable(2)] Action<bool> action = null)
		{
			string itemIcon = this.GetItemIcon(texture, itemId);
			if (!string.IsNullOrEmpty(itemIcon))
			{
				this.SetTextureByPathAsync(itemIcon, texture, action);
			}
		}

		// Token: 0x06031ACD RID: 203469 RVA: 0x00C609F8 File Offset: 0x00C5EBF8
		public UniTask SetItemIconTextureAsync(UUITexture texture, int itemId)
		{
			UiImageSettingModule.<SetItemIconTextureAsync>d__23 <SetItemIconTextureAsync>d__;
			<SetItemIconTextureAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetItemIconTextureAsync>d__.<>4__this = this;
			<SetItemIconTextureAsync>d__.texture = texture;
			<SetItemIconTextureAsync>d__.itemId = itemId;
			<SetItemIconTextureAsync>d__.<>1__state = -1;
			<SetItemIconTextureAsync>d__.<>t__builder.Start<UiImageSettingModule.<SetItemIconTextureAsync>d__23>(ref <SetItemIconTextureAsync>d__);
			return <SetItemIconTextureAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031ACE RID: 203470 RVA: 0x00C60A4C File Offset: 0x00C5EC4C
		private string GetRoleIcon(string path, UUITexture texture, int roleId)
		{
			TArray<FName> componentTags = texture.ComponentTags;
			if (componentTags.Num() == 0)
			{
				return path;
			}
			ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
			string tag = componentTags.Get(0).ToString();
			string roleConfigParam = ConfigBase<ComponentConfig>.Instance.GetRoleConfigParam(tag);
			return ConfigBase<RoleConfig>.Instance.GetRoleConfigValueByParam(roleId, roleConfigParam, tag) ?? "";
		}

		// Token: 0x06031ACF RID: 203471 RVA: 0x00C60AB0 File Offset: 0x00C5ECB0
		public void SetRoleIconSync(string path, UUITexture texture, int roleId, EUiViewName viewName, [Nullable(2)] Action<bool> callback = null)
		{
			string roleIcon = this.GetRoleIcon(path, texture, roleId);
			this.SetTextureByPathSync(roleIcon, texture, viewName, callback);
		}

		// Token: 0x06031AD0 RID: 203472 RVA: 0x00C60AD4 File Offset: 0x00C5ECD4
		private string GetRoleSkinIcon(string path, UUITexture texture, int skinId)
		{
			TArray<FName> componentTags = texture.ComponentTags;
			if (componentTags.Num() == 0)
			{
				return path;
			}
			if (ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(skinId) == null)
			{
				return path;
			}
			string tag = componentTags.Get(0).ToString();
			string roleSkinConfigParam = ConfigBase<ComponentConfig>.Instance.GetRoleSkinConfigParam(tag);
			return ConfigBase<SkinConfig>.Instance.GetRoleSkinConfigValueByParam(skinId, roleSkinConfigParam, tag) ?? "";
		}

		// Token: 0x06031AD1 RID: 203473 RVA: 0x00C60B44 File Offset: 0x00C5ED44
		public void SetRoleSkinIconAsync(string path, UUITexture texture, int skinId, [Nullable(2)] Action<bool> callback = null)
		{
			string roleSkinIcon = this.GetRoleSkinIcon(path, texture, skinId);
			this.SetTextureByPathAsync(roleSkinIcon, texture, callback);
		}

		// Token: 0x06031AD2 RID: 203474 RVA: 0x00C60B68 File Offset: 0x00C5ED68
		public void SetRoleSkinIconSync(string path, UUITexture texture, int skinId, EUiViewName viewName, [Nullable(2)] Action<bool> callback = null)
		{
			string roleSkinIcon = this.GetRoleSkinIcon(path, texture, skinId);
			this.SetTextureByPathSync(roleSkinIcon, texture, viewName, callback);
		}

		// Token: 0x06031AD3 RID: 203475 RVA: 0x00C60B8C File Offset: 0x00C5ED8C
		public void SetRoleIconAsync(string path, UUITexture texture, int roleId, [Nullable(2)] Action<bool> callback = null)
		{
			string roleIcon = this.GetRoleIcon(path, texture, roleId);
			this.SetTextureByPathAsync(roleIcon, texture, callback);
		}

		// Token: 0x06031AD4 RID: 203476 RVA: 0x00C60BB0 File Offset: 0x00C5EDB0
		private string GetElementIcon(string path, UUITexture texture, int elementId)
		{
			TArray<FName> componentTags = texture.ComponentTags;
			if (componentTags.Num() == 0)
			{
				return path;
			}
			ConfigBase<ElementInfoConfig>.Instance.GetElementInfo(elementId);
			string tag = componentTags.Get(0).ToString();
			string elementConfigParam = ConfigBase<ComponentConfig>.Instance.GetElementConfigParam(tag);
			return ConfigBase<ElementInfoConfig>.Instance.GetElementInfoValueByParam(elementId, elementConfigParam, tag) ?? "";
		}

		// Token: 0x06031AD5 RID: 203477 RVA: 0x00C60C14 File Offset: 0x00C5EE14
		public void SetElementIconSync(string path, UUITexture texture, int elementId, EUiViewName viewName)
		{
			string elementIcon = this.GetElementIcon(path, texture, elementId);
			this.SetTextureByPathSync(elementIcon, texture, viewName, null);
		}

		// Token: 0x06031AD6 RID: 203478 RVA: 0x00C60C38 File Offset: 0x00C5EE38
		public void SetElementIcon(string path, UUITexture texture, int elementId)
		{
			string elementIcon = this.GetElementIcon(path, texture, elementId);
			this.SetTextureByPathAsync(elementIcon, texture, null);
		}

		// Token: 0x06031AD7 RID: 203479 RVA: 0x00C60C58 File Offset: 0x00C5EE58
		private string GetMonsterIcon(string path, UUITexture texture, int monsterInfoId)
		{
			TArray<FName> componentTags = texture.ComponentTags;
			if (componentTags.Num() == 0 || monsterInfoId == 0)
			{
				return path;
			}
			ConfigBase<MonsterInfoConfig>.Instance.GetMonsterInfoConfig(monsterInfoId);
			string tag = componentTags.Get(0).ToString();
			string monsterConfigParam = ConfigBase<ComponentConfig>.Instance.GetMonsterConfigParam(tag);
			return ConfigBase<MonsterInfoConfig>.Instance.GetMonsterInfoConfigValueByParam(monsterInfoId, monsterConfigParam, tag) ?? "";
		}

		// Token: 0x06031AD8 RID: 203480 RVA: 0x00C60CC0 File Offset: 0x00C5EEC0
		public void SetMonsterIconSync(string path, UUITexture texture, int monsterInfoId, EUiViewName viewName)
		{
			string monsterIcon = this.GetMonsterIcon(path, texture, monsterInfoId);
			this.SetTextureByPathSync(monsterIcon, texture, viewName, null);
		}

		// Token: 0x06031AD9 RID: 203481 RVA: 0x00C60CE4 File Offset: 0x00C5EEE4
		public void SetMonsterIconAsync(string path, UUITexture texture, int monsterInfoId)
		{
			string monsterIcon = this.GetMonsterIcon(path, texture, monsterInfoId);
			this.SetTextureByPathAsync(monsterIcon, texture, null);
		}

		// Token: 0x06031ADA RID: 203482 RVA: 0x00C60D04 File Offset: 0x00C5EF04
		private string GetDungeonEntranceIcon(string path, UUITexture texture, int entranceId)
		{
			TArray<FName> componentTags = texture.ComponentTags;
			if (componentTags.Num() == 0 || entranceId == 0)
			{
				return path;
			}
			string tag = componentTags.Get(0).ToString();
			string dungeonEntranceConfigParam = ConfigBase<ComponentConfig>.Instance.GetDungeonEntranceConfigParam(tag);
			return ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetConfigValueByParam(entranceId, dungeonEntranceConfigParam, tag) ?? "";
		}

		// Token: 0x06031ADB RID: 203483 RVA: 0x00C60D60 File Offset: 0x00C5EF60
		public void SetDungeonEntranceIconSync(string path, UUITexture texture, int entranceId, EUiViewName viewName)
		{
			string dungeonEntranceIcon = this.GetDungeonEntranceIcon(path, texture, entranceId);
			this.SetTextureByPathSync(dungeonEntranceIcon, texture, viewName, null);
		}

		// Token: 0x06031ADC RID: 203484 RVA: 0x00C60D84 File Offset: 0x00C5EF84
		public void SetDungeonEntranceIconAsync(string path, UUITexture texture, int entranceId)
		{
			string dungeonEntranceIcon = this.GetDungeonEntranceIcon(path, texture, entranceId);
			this.SetTextureByPathAsync(dungeonEntranceIcon, texture, null);
		}

		// Token: 0x06031ADD RID: 203485 RVA: 0x00C60DA4 File Offset: 0x00C5EFA4
		public void SetNiagaraTextureAsync(string iconPath, [Nullable(2)] UUINiagara niagara, string emitterName, string variableName, [Nullable(2)] Action<bool> callback = null)
		{
			if (GlobalData.World == null)
			{
				return;
			}
			if (niagara == null || !niagara.IsValid())
			{
				return;
			}
			base.CancelResource(niagara);
			int resourceId = Singleton<ResourceSystem>.Instance.LoadAsync<UTexture>(iconPath, delegate([Nullable(2)] UTexture image, string path)
			{
				this.DeleteResourceHandle(niagara);
				if (!niagara.IsValid())
				{
					return;
				}
				if (image == null || !image.IsValid())
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.UiImageSetting;
					ELogAuthor author = ELogAuthor.XXJ;
					string message = "设置Texture失败，图片加载失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("图片路径", path);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					Action<bool> callback2 = callback;
					if (callback2 == null)
					{
						return;
					}
					callback2(false);
					return;
				}
				else
				{
					niagara.SetNiagaraEmitterCustomTexture(emitterName, variableName, image);
					Action<bool> callback3 = callback;
					if (callback3 == null)
					{
						return;
					}
					callback3(true);
					return;
				}
			}, 102, "js_undefined");
			base.SetResourceId(niagara, resourceId);
		}

		// Token: 0x06031ADE RID: 203486 RVA: 0x00C60E34 File Offset: 0x00C5F034
		public void SetNiagaraTextureSync(string iconPath, [Nullable(2)] UUINiagara niagara, string emitterName, string variableName, EUiViewName viewName, [Nullable(2)] Action<bool> callback = null)
		{
			if (GlobalData.World == null)
			{
				return;
			}
			if (niagara == null || !niagara.IsValid())
			{
				return;
			}
			UiViewInfo uiViewInfo = Singleton<UiConfig>.Instance.TryGetViewInfo(viewName);
			if (uiViewInfo == null || uiViewInfo.LoadAsync)
			{
				UTexture inTexture = Singleton<ResourceSystem>.Instance.Load<UTexture>(iconPath, "js_undefined");
				niagara.SetNiagaraEmitterCustomTexture(emitterName, variableName, inTexture);
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiImageSetting;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "该界面不允许同步加载,Texture改为异步加载";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", viewName);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.SetNiagaraTextureAsync(iconPath, niagara, emitterName, variableName, callback);
		}

		// Token: 0x06031ADF RID: 203487 RVA: 0x00C60EC8 File Offset: 0x00C5F0C8
		[return: Nullable(2)]
		private ULGUISpriteData_BaseObject TryGetSpriteFromAtlasManager(string path)
		{
			UUIDynamicSpriteAtlasMgr dynamicSpriteAtlasMgr = ALGUIManagerActor.GetDynamicSpriteAtlasMgr(GlobalData.World);
			if (dynamicSpriteAtlasMgr == null)
			{
				return null;
			}
			return dynamicSpriteAtlasMgr.GetSpriteData(path);
		}
	}
}
