using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Menu.DropDownLogic
{
	// Token: 0x020057D2 RID: 22482
	[NullableContext(1)]
	[Nullable(0)]
	public class LanguageLogic : DropDownLogicBase
	{
		// Token: 0x0603924D RID: 234061 RVA: 0x00E7D24C File Offset: 0x00E7B44C
		public override IReadOnlyList<object> GetDropDownDataList()
		{
			List<global::LanguageDefine> list = new List<global::LanguageDefine>();
			this.LanguageDefineTypeIndexMap.Clear();
			Dictionary<int, int> languageSortIdMap = new Dictionary<int, int>();
			int targetConfig = ControllerBase<MenuController>.Instance.GetTargetConfig(EFunction.TEXTLANGUAGE);
			foreach (global::LanguageDefine languageDefine in MenuTool.GetLanguageDefineData())
			{
				int languageType = languageDefine.LanguageType;
				Aki.Config.LanguageDefine? languageDefineById = ConfigBase<LanguageConfig>.Instance.GetLanguageDefineById(languageType);
				if (languageDefineById == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.TextLanguageSearch;
					ELogAuthor author = ELogAuthor.YYZ;
					string message = "设置系统语言定义不存在,请检查s.设置系统 LanguageDefine";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("语言类型Id", languageType);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else if (languageType == targetConfig || languageDefineById.Value.IsShow)
				{
					list.Add(languageDefine);
					languageSortIdMap[languageType] = languageDefineById.Value.SortId;
				}
			}
			list.Sort(delegate(global::LanguageDefine a, global::LanguageDefine b)
			{
				int num;
				if (!languageSortIdMap.TryGetValue(a.LanguageType, out num))
				{
					num = 0;
				}
				int num2;
				if (!languageSortIdMap.TryGetValue(b.LanguageType, out num2))
				{
					num2 = 0;
				}
				return num - num2;
			});
			for (int i = 0; i < list.Count; i++)
			{
				this.LanguageDefineTypeIndexMap[list[i].LanguageType] = i;
			}
			return list.Cast<object>().ToList<object>();
		}

		// Token: 0x0603924E RID: 234062 RVA: 0x00E7D3A8 File Offset: 0x00E7B5A8
		public override TableTextArgNew GetDataTextId(object data, MenuData menuData)
		{
			global::LanguageDefine languageDefine = (global::LanguageDefine)data;
			return new TableTextArgNew(menuData.OptionsNameList[languageDefine.LanguageType], Array.Empty<object>());
		}

		// Token: 0x0603924F RID: 234063 RVA: 0x00E7D3D8 File Offset: 0x00E7B5D8
		public unsafe override void TriggerSelectChange(object data, MenuData menuData)
		{
			int targetConfig = ControllerBase<MenuController>.Instance.GetTargetConfig(menuData.FunctionId);
			global::LanguageDefine languageDefine = (global::LanguageDefine)data;
			if (targetConfig == languageDefine.LanguageType)
			{
				return;
			}
			Singleton<GameSettingsManager>.Instance.HandleValueChange(menuData.FunctionId, languageDefine.LanguageType, EGameSettingsApplyReason.WhenUi);
			ModelBase<MenuModel>.Instance.IsEdited = true;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.TextLanguageSearch;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "设置语言";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("选择语言", Singleton<GameSettingsManager>.Instance.GetLanguageCodeById(languageDefine.LanguageType));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("实际语言", Singleton<LanguageSystem>.Instance.PackageLanguage);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x06039250 RID: 234064 RVA: 0x00E7D498 File Offset: 0x00E7B698
		public override int GetDefaultIndex(MenuData menuData)
		{
			int targetConfig = ControllerBase<MenuController>.Instance.GetTargetConfig(menuData.FunctionId);
			int result;
			if (!this.LanguageDefineTypeIndexMap.TryGetValue(targetConfig, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x0402085D RID: 133213
		private readonly Dictionary<int, int> LanguageDefineTypeIndexMap = new Dictionary<int, int>();
	}
}
