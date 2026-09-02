using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D7F RID: 19839
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class UiNavigationConfig : ConfigBase<UiNavigationConfig>
	{
		// Token: 0x06033616 RID: 210454 RVA: 0x00CDA0CC File Offset: 0x00CD82CC
		public bool GetHighlightWhenMouseMoveOut()
		{
			bool? boolConfig = ConfigCommonParamById.GetBoolConfig("highlight_when_mouse_moveout");
			if (boolConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.UiNavigation, ELogAuthor.XXJ, "鼠标移出button表现参数找不到, 请检测c.参数字段\"highlight_when_mouse_moveout\"", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return boolConfig.GetValueOrDefault();
		}

		// Token: 0x06033617 RID: 210455 RVA: 0x00CDA114 File Offset: 0x00CD8314
		public bool GetMobileHighlight()
		{
			bool? boolConfig = ConfigCommonParamById.GetBoolConfig("mobile_highlight");
			if (boolConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.UiNavigation, ELogAuthor.XXJ, "移动端是否显示按钮高亮参数找不到, 请检测c.参数字段\"mobile_highlight\"", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return boolConfig.GetValueOrDefault();
		}

		// Token: 0x06033618 RID: 210456 RVA: 0x00CDA15C File Offset: 0x00CD835C
		public bool GetPcPress()
		{
			bool? boolConfig = ConfigCommonParamById.GetBoolConfig("pc_press");
			if (boolConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.UiNavigation, ELogAuthor.XXJ, "PC端是否显示按钮按下参数找不到, 请检测c.参数字段\"pc_press\"", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return boolConfig.GetValueOrDefault();
		}

		// Token: 0x06033619 RID: 210457 RVA: 0x00CDA1A4 File Offset: 0x00CD83A4
		public float GetNavigateTolerance()
		{
			float? floatConfig = ConfigCommonParamById.GetFloatConfig("navigate_tolerance");
			if (floatConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.UiNavigation, ELogAuthor.XXJ, "导航组同向误差找不到, 请检测c.参数字段\"navigate_tolerance\"", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return floatConfig.GetValueOrDefault();
		}

		// Token: 0x0603361A RID: 210458 RVA: 0x00CDA1EC File Offset: 0x00CD83EC
		public HotKeyView? GetHotKeyViewConfig(int id)
		{
			HotKeyView? config = ConfigHotKeyViewById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiNavigation;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "热键界面配置找不到";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x0603361B RID: 210459 RVA: 0x00CDA23C File Offset: 0x00CD843C
		public HotKeyMap? GetHotKeyMapConfig(int id)
		{
			if (id == -1)
			{
				return null;
			}
			HotKeyMap? config = ConfigHotKeyMapById.GetConfig(id, true);
			if (config == null && id != -1)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiNavigation;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "热键映射配置找不到";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x0603361C RID: 210460 RVA: 0x00CDA29C File Offset: 0x00CD849C
		public HotKeyType? GetHotKeyTypeConfig(int id)
		{
			return ConfigHotKeyTypeById.GetConfig(id, true);
		}

		// Token: 0x0603361D RID: 210461 RVA: 0x00CDA2A8 File Offset: 0x00CD84A8
		public HotKeyIcon? GetHotKeyIconConfig(string keyName, bool warnOnly = false)
		{
			HotKeyIcon? config = ConfigHotKeyIconByKeyName.GetConfig(keyName, true);
			if (config == null)
			{
				if (warnOnly)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.UiNavigation;
					ELogAuthor author = ELogAuthor.XXJ;
					string message = "快捷键图标配置找不到";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("keyName", keyName);
					instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.UiNavigation;
					ELogAuthor author2 = ELogAuthor.XXJ;
					string message2 = "快捷键图标配置找不到";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("keyName", keyName);
					instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
			}
			return config;
		}

		// Token: 0x0603361E RID: 210462 RVA: 0x00CDA320 File Offset: 0x00CD8520
		[return: Nullable(2)]
		public string GetHotKeyText(string id)
		{
			HotKeyText? config = ConfigHotKeyTextByTextId.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiNavigation;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "快捷键文本配置找不到";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TextId", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			if (config == null)
			{
				return null;
			}
			return config.GetValueOrDefault().Name;
		}

		// Token: 0x0603361F RID: 210463 RVA: 0x00CDA384 File Offset: 0x00CD8584
		[return: Nullable(2)]
		public string GetHotKeyIcon(string keyName, bool warnOnly = false)
		{
			HotKeyIcon? hotKeyIconConfig = this.GetHotKeyIconConfig(keyName, warnOnly);
			if (hotKeyIconConfig == null)
			{
				return null;
			}
			return hotKeyIconConfig.GetValueOrDefault().Icon;
		}
	}
}
