using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A60 RID: 19040
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class UiViewStorage : Singleton<UiViewStorage>
	{
		// Token: 0x06031B9D RID: 203677 RVA: 0x00C7375C File Offset: 0x00C7195C
		[NullableContext(2)]
		public UiTsInfo GetUiTsInfo(EUiViewName viewName)
		{
			UiTsInfo result;
			if (this.UiTsInfoMap.TryGetValue(viewName, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x06031B9E RID: 203678 RVA: 0x00C7377C File Offset: 0x00C7197C
		public unsafe void RegisterUiTsInfo(TUiTsInfo[] uiViewTsInfoList)
		{
			foreach (TUiTsInfo tuiTsInfo in uiViewTsInfoList)
			{
				EUiViewName viewName = tuiTsInfo.ViewName;
				try
				{
					UiTsInfo value = new UiTsInfo
					{
						Ctor = tuiTsInfo.CreateUiView,
						ResourceId = tuiTsInfo.ResourceId,
						SourceType = new ESourceType?(tuiTsInfo.SourceType.GetValueOrDefault())
					};
					this.UiTsInfoMap[viewName] = value;
				}
				catch (Exception ex)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.UiManager;
					ELogAuthor author = ELogAuthor.TL;
					string message = "[RegisterUiTsInfo]流程执行异常 1";
					Exception error = ex;
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("error", ex.Message);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ViewName", viewName);
					instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}
		}

		// Token: 0x06031B9F RID: 203679 RVA: 0x00C7386C File Offset: 0x00C71A6C
		public void RegisterUiViewInfoDynamicData([TupleElementNames(new string[]
		{
			"ViewName",
			"DynamicDataCtor"
		})] [Nullable(new byte[]
		{
			1,
			0,
			1
		})] ValueTuple<EUiViewName, TViewInfoDynamicData>[] uiViewAbilitiesList)
		{
			foreach (ValueTuple<EUiViewName, TViewInfoDynamicData> valueTuple in uiViewAbilitiesList)
			{
				EUiViewName item = valueTuple.Item1;
				UiTsInfo uiTsInfo;
				if (!this.UiTsInfoMap.TryGetValue(item, out uiTsInfo))
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.UiCore;
					ELogAuthor author = ELogAuthor.TL;
					string message = "[RegisterUiViewAbilities]界面信息不存在";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ViewName", item);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
				else
				{
					uiTsInfo.DynamicDataCtor = valueTuple.Item2;
				}
			}
		}

		// Token: 0x0401CED3 RID: 118483
		private readonly Dictionary<EUiViewName, UiTsInfo> UiTsInfoMap = new Dictionary<EUiViewName, UiTsInfo>();
	}
}
