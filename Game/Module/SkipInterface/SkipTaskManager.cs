using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.SkipInterface
{
	// Token: 0x02004F22 RID: 20258
	public class SkipTaskManager : IStaticVariableResetter
	{
		// Token: 0x0603458A RID: 214410 RVA: 0x00D197F6 File Offset: 0x00D179F6
		static SkipTaskManager()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(SkipTaskManager.CreateStaticDefaultValue), new Action(SkipTaskManager.ResetStaticDefaultValue));
		}

		// Token: 0x0603458B RID: 214411 RVA: 0x00D19818 File Offset: 0x00D17A18
		public static void CreateStaticDefaultValue()
		{
			SkipTaskManager.SkipTaskMap = new Dictionary<ESkipName, SkipTask>();
			SkipTaskManager.LimitRingViewNameList = new HashSet<EUiViewName>
			{
				EUiViewName.RoleRootView,
				EUiViewName.RoleDevelopRootView,
				EUiViewName.CalabashRootView,
				EUiViewName.SkinBuyDetailView,
				EUiViewName.FlySkinBuyDetailView,
				EUiViewName.SkinRootView,
				EUiViewName.MotorcycleRootView,
				EUiViewName.SpringManorAtmosphereLevelView,
				EUiViewName.FurnitureAreaSelectView,
				EUiViewName.CumulativeShopTaskView,
				EUiViewName.AdventureGuideView,
				EUiViewName.ActivityRecommendView,
				EUiViewName.RoleOrnamentShowView,
				EUiViewName.CommonActivityView,
				EUiViewName.GachaMainView
			};
		}

		// Token: 0x0603458C RID: 214412 RVA: 0x00D198ED File Offset: 0x00D17AED
		public static void ResetStaticDefaultValue()
		{
			SkipTaskManager.SkipTaskMap = null;
			SkipTaskManager.LimitRingViewNameList = null;
		}

		// Token: 0x0603458D RID: 214413 RVA: 0x00D198FB File Offset: 0x00D17AFB
		public static void CheckContainRingView(EUiViewName viewName)
		{
			if (SkipTaskManager.CheckContainLimitViewName(viewName))
			{
				Singleton<UiManager>.Instance.CloseHistoryRingView(viewName, null);
			}
		}

		// Token: 0x0603458E RID: 214414 RVA: 0x00D19911 File Offset: 0x00D17B11
		public static bool CheckContainLimitViewName(EUiViewName viewName)
		{
			return SkipTaskManager.LimitRingViewNameList.Contains(viewName);
		}

		// Token: 0x0603458F RID: 214415 RVA: 0x00D19920 File Offset: 0x00D17B20
		[NullableContext(2)]
		public unsafe static void RunByConfigId(int id, object @params = null)
		{
			AccessPath? accessPathConfig = ConfigBase<SkipInterfaceConfig>.Instance.GetAccessPathConfig(id);
			if (accessPathConfig == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SkipInterface;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "开始跳转任务时,没有在途径表中找到对应配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			ESkipName skipName = (ESkipName)accessPathConfig.Value.SkipName;
			if (skipName == ESkipName.NoSkip)
			{
				return;
			}
			FunctionModel instance2 = ModelBase<FunctionModel>.Instance;
			foreach (KeyValuePair<int, string> keyValuePair in accessPathConfig.Value.FunctionOpenCheckMap())
			{
				int key = keyValuePair.Key;
				string value = keyValuePair.Value;
				if (!instance2.IsOpen(key))
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.SkipInterface;
					ELogAuthor author2 = ELogAuthor.XXJ;
					string message2 = "开始跳转任务时,对应功能未开启，不会跳转";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("skipTaskName", skipName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("functionId", key);
					instance3.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode(value, Array.Empty<object>());
					return;
				}
			}
			SkipTask skipTask = SkipTaskManager.GetSkipTask(skipName);
			if (skipTask == null)
			{
				skipTask = SkipTaskManager.NewSkipTask(skipName);
			}
			if (skipTask == null)
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.SkipInterface;
				ELogAuthor author3 = ELogAuthor.XXJ;
				string message3 = "开始跳转任务时,没有配对应的跳转任务";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("途径表Id", id);
				instance4.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			skipTask.Run(new object[]
			{
				accessPathConfig.Value.Val1,
				accessPathConfig.Value.Val2,
				accessPathConfig.Value.Val3,
				@params
			});
		}

		// Token: 0x06034590 RID: 214416 RVA: 0x00D19B00 File Offset: 0x00D17D00
		public static void Run(ESkipName name, [Nullable(new byte[]
		{
			1,
			2
		})] params object[] @params)
		{
			SkipTask skipTask = SkipTaskManager.GetSkipTask(name);
			if (skipTask == null)
			{
				skipTask = SkipTaskManager.NewSkipTask(name);
			}
			if (skipTask != null)
			{
				skipTask.Run(@params);
			}
		}

		// Token: 0x06034591 RID: 214417 RVA: 0x00D19B28 File Offset: 0x00D17D28
		public static UniTask<ESkipTaskFinishType?> AsyncRun(ESkipName name, [Nullable(new byte[]
		{
			1,
			2
		})] params object[] @params)
		{
			SkipTaskManager.<AsyncRun>d__9 <AsyncRun>d__;
			<AsyncRun>d__.<>t__builder = AsyncUniTaskMethodBuilder<ESkipTaskFinishType?>.Create();
			<AsyncRun>d__.name = name;
			<AsyncRun>d__.@params = @params;
			<AsyncRun>d__.<>1__state = -1;
			<AsyncRun>d__.<>t__builder.Start<SkipTaskManager.<AsyncRun>d__9>(ref <AsyncRun>d__);
			return <AsyncRun>d__.<>t__builder.Task;
		}

		// Token: 0x06034592 RID: 214418 RVA: 0x00D19B74 File Offset: 0x00D17D74
		[NullableContext(2)]
		private static SkipTask NewSkipTask(ESkipName name)
		{
			if (name < ESkipName.SkipToWorldMapView)
			{
				return null;
			}
			Dictionary<ESkipName, Type> skipClassMap = SkipInterfaceDefine.GetSkipClassMap();
			Type type;
			if (skipClassMap == null || !skipClassMap.TryGetValue(name, out type))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SkipInterface;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "创建跳转任务时，skipClassMap中找不到对应类";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", name);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			SkipTask skipTask = (SkipTask)Activator.CreateInstance(type);
			if (skipTask == null)
			{
				return null;
			}
			SkipTaskManager.SkipTaskMap[name] = skipTask;
			skipTask.Initialize();
			return skipTask;
		}

		// Token: 0x06034593 RID: 214419 RVA: 0x00D19BF0 File Offset: 0x00D17DF0
		[NullableContext(2)]
		private static SkipTask GetSkipTask(ESkipName name)
		{
			SkipTask result;
			SkipTaskManager.SkipTaskMap.TryGetValue(name, out result);
			return result;
		}

		// Token: 0x06034594 RID: 214420 RVA: 0x00D19C0C File Offset: 0x00D17E0C
		public static void Stop(ESkipName name)
		{
			SkipTask skipTask;
			if (!SkipTaskManager.SkipTaskMap.TryGetValue(name, out skipTask))
			{
				return;
			}
			if (!skipTask.GetIsRunning())
			{
				return;
			}
			skipTask.Stop();
		}

		// Token: 0x06034595 RID: 214421 RVA: 0x00D19C38 File Offset: 0x00D17E38
		public static void Clear()
		{
			foreach (SkipTask skipTask in SkipTaskManager.SkipTaskMap.Values)
			{
				skipTask.Destroy();
			}
			SkipTaskManager.SkipTaskMap.Clear();
			Singleton<Log>.Instance.Info(ELogModule.SkipInterface, ELogAuthor.TL, "[Clear] 清理所有跳转任务", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0401E304 RID: 123652
		[Nullable(1)]
		private static Dictionary<ESkipName, SkipTask> SkipTaskMap;

		// Token: 0x0401E305 RID: 123653
		[Nullable(1)]
		private static HashSet<EUiViewName> LimitRingViewNameList;
	}
}
