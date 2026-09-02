using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using CSharpScript.Core.Common;
using CSharpScript.Launcher.Download;
using CSharpScript.Launcher.Ui.HotFix;
using CSharpScript.Launcher.Util;
using CSharpScript.Typing;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.BaseConfig
{
	// Token: 0x02004676 RID: 18038
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class BaseConfigController : Singleton<BaseConfigController>
	{
		// Token: 0x0602F02F RID: 192559 RVA: 0x00B22EDC File Offset: 0x00B210DC
		[NullableContext(0)]
		public UniTask<bool> RequestBaseData([Nullable(1)] HotFixManager view = null)
		{
			BaseConfigController.<RequestBaseData>d__4 <RequestBaseData>d__;
			<RequestBaseData>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestBaseData>d__.<>4__this = this;
			<RequestBaseData>d__.view = view;
			<RequestBaseData>d__.<>1__state = -1;
			<RequestBaseData>d__.<>t__builder.Start<BaseConfigController.<RequestBaseData>d__4>(ref <RequestBaseData>d__);
			return <RequestBaseData>d__.<>t__builder.Task;
		}

		// Token: 0x0602F030 RID: 192560 RVA: 0x00B22F28 File Offset: 0x00B21128
		private Dictionary<string, EntryJson> ParseEntryMap(string contentJson)
		{
			Dictionary<string, EntryJson> result;
			using (JsonDocument jsonDocument = JsonDocument.Parse(contentJson, default(JsonDocumentOptions)))
			{
				result = this.ParseEntryMap(jsonDocument.RootElement);
			}
			return result;
		}

		// Token: 0x0602F031 RID: 192561 RVA: 0x00B22F70 File Offset: 0x00B21170
		private Dictionary<string, EntryJson> ParseEntryMap(JsonElement rootElement)
		{
			Dictionary<string, EntryJson> dictionary = new Dictionary<string, EntryJson>();
			foreach (JsonProperty jsonProperty in rootElement.EnumerateObject())
			{
				if (jsonProperty.Value.ValueKind == JsonValueKind.Object)
				{
					EntryJson entryJson = LauncherJson.Parse<EntryJson>(jsonProperty.Value, null);
					if (entryJson != null)
					{
						dictionary.Add(jsonProperty.Name, entryJson);
					}
				}
			}
			return dictionary;
		}

		// Token: 0x0602F032 RID: 192562 RVA: 0x00B22FFC File Offset: 0x00B211FC
		private unsafe void ParseGrayBox()
		{
			IGrayBoxConfig grayBox = this.GetCdnReturnConfigInfo().GrayBox;
			if (grayBox == null)
			{
				Singleton<LauncherLog>.Instance.Debug("ParseGrayBox: 没有灰度配置", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (grayBox.Items == null || grayBox.Items.Count == 0)
			{
				Singleton<LauncherLog>.Instance.Error("ParseGrayBox: 灰度配置为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			for (int i = 0; i < grayBox.Items.Count; i++)
			{
				IGrayBoxItemConfig grayBoxItemConfig = grayBox.Items[i];
				if (grayBoxItemConfig.Name == null || grayBoxItemConfig.Name.Length == 0)
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "Name参数无效";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", grayBoxItemConfig.Name);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Content", Json.Stringify<IGrayBoxItemConfig>(grayBoxItemConfig, null));
					instance.Error(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				else if (Singleton<BaseConfigModel>.Instance.GrayBoxConfigMap.ContainsKey(grayBoxItemConfig.Name))
				{
					LauncherLog instance2 = Singleton<LauncherLog>.Instance;
					string message2 = "存在相同的Name";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Name", grayBoxItemConfig.Name);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Content", Json.Stringify<IGrayBoxItemConfig>(grayBoxItemConfig, null));
					instance2.Error(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				}
				else
				{
					if (grayBoxItemConfig.Divisor != null)
					{
						int? num = grayBoxItemConfig.Divisor;
						int num2 = 1;
						if (num.GetValueOrDefault() <= num2 & num != null)
						{
							LauncherLog instance3 = Singleton<LauncherLog>.Instance;
							string message3 = "Divisor必须大于1";
							<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("Name", grayBoxItemConfig.Name);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("Divisor", grayBoxItemConfig.Divisor);
							instance3.Error(message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
							goto IL_539;
						}
						if (grayBoxItemConfig.Left == null)
						{
							LauncherLog instance4 = Singleton<LauncherLog>.Instance;
							string message4 = "Left参数无效";
							<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("Name", grayBoxItemConfig.Name);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("Left", grayBoxItemConfig.Left);
							instance4.Error(message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
							goto IL_539;
						}
						if (grayBoxItemConfig.Right == null)
						{
							LauncherLog instance5 = Singleton<LauncherLog>.Instance;
							string message5 = "Right参数无效";
							<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray5 = default(<>y__InlineArray2<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 0) = new ValueTuple<string, object>("Name", grayBoxItemConfig.Name);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 1) = new ValueTuple<string, object>("Right", grayBoxItemConfig.Right);
							instance5.Error(message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray5, 2));
							goto IL_539;
						}
						num = grayBoxItemConfig.Left;
						int? right = grayBoxItemConfig.Right;
						if (num.GetValueOrDefault() >= right.GetValueOrDefault() & (num != null & right != null))
						{
							LauncherLog instance6 = Singleton<LauncherLog>.Instance;
							string message6 = "Left必须小于Right的值";
							<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray6 = default(<>y__InlineArray3<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 0) = new ValueTuple<string, object>("Name", grayBoxItemConfig.Name);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 1) = new ValueTuple<string, object>("Left", grayBoxItemConfig.Left);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 2) = new ValueTuple<string, object>("Right", grayBoxItemConfig.Right);
							instance6.Error(message6, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray6, 3));
							goto IL_539;
						}
						right = grayBoxItemConfig.Right;
						num = grayBoxItemConfig.Divisor;
						if (right.GetValueOrDefault() > num.GetValueOrDefault() & (right != null & num != null))
						{
							LauncherLog instance7 = Singleton<LauncherLog>.Instance;
							string message7 = "Right必须小于等于Divisor的值";
							<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray7 = default(<>y__InlineArray3<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray7, 0) = new ValueTuple<string, object>("Name", grayBoxItemConfig.Name);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray7, 1) = new ValueTuple<string, object>("Right", grayBoxItemConfig.Right);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray7, 2) = new ValueTuple<string, object>("Divisor", grayBoxItemConfig.Divisor);
							instance7.Error(message7, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray7, 3));
							goto IL_539;
						}
					}
					IGrayBoxItem grayBoxItem = new IGrayBoxItem
					{
						Divisor = grayBoxItemConfig.Divisor.GetValueOrDefault(),
						Left = grayBoxItemConfig.Left.GetValueOrDefault(),
						Right = grayBoxItemConfig.Right.GetValueOrDefault()
					};
					if (grayBoxItemConfig.Ids != null && grayBoxItemConfig.Ids.Count > 0)
					{
						grayBoxItem.PlayerIds = new HashSet<int>();
						for (int j = 0; j < grayBoxItemConfig.Ids.Count; j++)
						{
							grayBoxItem.PlayerIds.Add(grayBoxItemConfig.Ids[j]);
						}
					}
					Singleton<BaseConfigModel>.Instance.GrayBoxConfigMap[grayBoxItemConfig.Name] = grayBoxItem;
					LauncherLog instance8 = Singleton<LauncherLog>.Instance;
					string message8 = "ParseGrayBox: 添加灰度配置";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", grayBoxItemConfig.Name);
					instance8.Debug(message8, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				IL_539:;
			}
		}

		// Token: 0x0602F033 RID: 192563 RVA: 0x00B2355C File Offset: 0x00B2175C
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public UniTask<IResponse> DoRequest(List<string> httpList, Func<string, string> getHttpFunction, [Nullable(2)] HotFixManager view, [Nullable(new byte[]
		{
			2,
			1,
			1
		})] Func<string, IResponse, bool> resolveFunc = null)
		{
			BaseConfigController.<DoRequest>d__8 <DoRequest>d__;
			<DoRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<IResponse>.Create();
			<DoRequest>d__.httpList = httpList;
			<DoRequest>d__.getHttpFunction = getHttpFunction;
			<DoRequest>d__.view = view;
			<DoRequest>d__.resolveFunc = resolveFunc;
			<DoRequest>d__.<>1__state = -1;
			<DoRequest>d__.<>t__builder.Start<BaseConfigController.<DoRequest>d__8>(ref <DoRequest>d__);
			return <DoRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0602F034 RID: 192564 RVA: 0x00B235B8 File Offset: 0x00B217B8
		public unsafe bool CheckGrayBoxHit(string name, int playerId)
		{
			if (string.IsNullOrEmpty(name))
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "name参数无效";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PlayerId", playerId);
				instance.Error(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			if (playerId == 0)
			{
				LauncherLog instance2 = Singleton<LauncherLog>.Instance;
				string message2 = "playerId参数无效";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Name", name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("PlayerId", playerId);
				instance2.Error(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				return false;
			}
			EHitResult ehitResult;
			if (Singleton<BaseConfigModel>.Instance.BoxResultMap.TryGetValue(name, out ehitResult))
			{
				return ehitResult == EHitResult.Hit;
			}
			IGrayBoxItem grayBoxItem;
			if (!Singleton<BaseConfigModel>.Instance.GrayBoxConfigMap.TryGetValue(name, out grayBoxItem))
			{
				LauncherLog instance3 = Singleton<LauncherLog>.Instance;
				string message3 = "不存在GrayBox数据";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("Name", name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("PlayerId", playerId);
				instance3.Error(message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
				return false;
			}
			if (grayBoxItem.Divisor != 0)
			{
				int num = playerId % grayBoxItem.Divisor;
				if (num >= grayBoxItem.Left && num < grayBoxItem.Right)
				{
					Singleton<BaseConfigModel>.Instance.BoxResultMap[name] = EHitResult.Hit;
					return true;
				}
			}
			if (grayBoxItem.PlayerIds != null && grayBoxItem.PlayerIds.Count > 0 && grayBoxItem.PlayerIds.Contains(playerId))
			{
				Singleton<BaseConfigModel>.Instance.BoxResultMap[name] = EHitResult.Hit;
				return true;
			}
			Singleton<BaseConfigModel>.Instance.BoxResultMap[name] = EHitResult.Miss;
			return false;
		}

		// Token: 0x0602F035 RID: 192565 RVA: 0x00B23784 File Offset: 0x00B21984
		public unsafe bool CheckGrayBoxHitByDeviceId(string name, string deviceId)
		{
			if (string.IsNullOrEmpty(name))
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "灰度检查: name参数无效";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("DeviceId", deviceId);
				instance.Error(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			if (string.IsNullOrEmpty(deviceId))
			{
				LauncherLog instance2 = Singleton<LauncherLog>.Instance;
				string message2 = "灰度检查: deviceId参数无效";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Name", name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("DeviceId", deviceId);
				instance2.Error(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				return false;
			}
			EHitResult ehitResult;
			if (Singleton<BaseConfigModel>.Instance.BoxResultMap.TryGetValue(name, out ehitResult))
			{
				return ehitResult == EHitResult.Hit;
			}
			IGrayBoxItem grayBoxItem;
			if (!Singleton<BaseConfigModel>.Instance.GrayBoxConfigMap.TryGetValue(name, out grayBoxItem))
			{
				LauncherLog instance3 = Singleton<LauncherLog>.Instance;
				string message3 = "灰度检查: 不存在GrayBox数据";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", name);
				instance3.Warn(message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			if (grayBoxItem.Divisor != 0)
			{
				string text = UKuroStaticLibrary.HashStringWithSHA1(deviceId);
				if (string.IsNullOrEmpty(text))
				{
					LauncherLog instance4 = Singleton<LauncherLog>.Instance;
					string message4 = "灰度检查: deviceId的SHA1值不合法";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("Name", name);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("DeviceId", deviceId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("SHA1", text ?? "");
					instance4.Error(message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
					return false;
				}
				int num = (int)(Convert.ToInt64(text.Substring(0, 8), 16) % (long)grayBoxItem.Divisor);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
				if (num >= grayBoxItem.Left && num < grayBoxItem.Right)
				{
					Singleton<BaseConfigModel>.Instance.BoxResultMap[name] = EHitResult.Hit;
					LauncherLog instance5 = Singleton<LauncherLog>.Instance;
					string message5 = "灰度检查: 命中";
					<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray5<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("Name", name);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("DeviceId", deviceId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("Mod", num);
					ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 3);
					string item = "Range";
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
					defaultInterpolatedStringHandler.AppendFormatted<int>(grayBoxItem.Left);
					defaultInterpolatedStringHandler.AppendLiteral(",");
					defaultInterpolatedStringHandler.AppendFormatted<int>(grayBoxItem.Right);
					ptr = new ValueTuple<string, object>(item, defaultInterpolatedStringHandler.ToStringAndClear());
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 4) = new ValueTuple<string, object>("Percent", ((float)(grayBoxItem.Right - grayBoxItem.Left) / (float)grayBoxItem.Divisor * 100f).ToString() + "%");
					instance5.Info(message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 5));
					return true;
				}
				LauncherLog instance6 = Singleton<LauncherLog>.Instance;
				string message6 = "灰度检查: 未命中";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray5 = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 0) = new ValueTuple<string, object>("Name", name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 1) = new ValueTuple<string, object>("DeviceId", deviceId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 2) = new ValueTuple<string, object>("Mod", num);
				ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 3);
				string item2 = "Range";
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(grayBoxItem.Left);
				defaultInterpolatedStringHandler.AppendLiteral(",");
				defaultInterpolatedStringHandler.AppendFormatted<int>(grayBoxItem.Right);
				ptr2 = new ValueTuple<string, object>(item2, defaultInterpolatedStringHandler.ToStringAndClear());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 4) = new ValueTuple<string, object>("Percent", ((float)(grayBoxItem.Right - grayBoxItem.Left) / (float)grayBoxItem.Divisor * 100f).ToString() + "%");
				instance6.Info(message6, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray5, 5));
			}
			Singleton<BaseConfigModel>.Instance.BoxResultMap[name] = EHitResult.Miss;
			return false;
		}

		// Token: 0x0602F036 RID: 192566 RVA: 0x00B23B7E File Offset: 0x00B21D7E
		[NullableContext(2)]
		public EntryJson GetCdnReturnConfigInfo()
		{
			return Singleton<BaseConfigModel>.Instance.EntryJson;
		}

		// Token: 0x0602F037 RID: 192567 RVA: 0x00B23B8A File Offset: 0x00B21D8A
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ICdnUrlData> GetCdnUrl()
		{
			EntryJson cdnReturnConfigInfo = this.GetCdnReturnConfigInfo();
			return ((cdnReturnConfigInfo != null) ? cdnReturnConfigInfo.CdnUrl : null) ?? null;
		}

		// Token: 0x0602F038 RID: 192568 RVA: 0x00B23BA4 File Offset: 0x00B21DA4
		public float? GetSpeedRatio()
		{
			EntryJson cdnReturnConfigInfo = this.GetCdnReturnConfigInfo();
			if (cdnReturnConfigInfo == null)
			{
				return null;
			}
			return cdnReturnConfigInfo.SpeedRatio;
		}

		// Token: 0x0602F039 RID: 192569 RVA: 0x00B23BCC File Offset: 0x00B21DCC
		public float? GetPriceRatio()
		{
			EntryJson cdnReturnConfigInfo = this.GetCdnReturnConfigInfo();
			if (cdnReturnConfigInfo == null)
			{
				return null;
			}
			return cdnReturnConfigInfo.PriceRatio;
		}

		// Token: 0x0602F03A RID: 192570 RVA: 0x00B23BF2 File Offset: 0x00B21DF2
		[NullableContext(2)]
		public IEvalConfig GetCdnEvalCfg()
		{
			EntryJson cdnReturnConfigInfo = this.GetCdnReturnConfigInfo();
			if (cdnReturnConfigInfo == null)
			{
				return null;
			}
			return cdnReturnConfigInfo.CdnEvalCfg;
		}

		// Token: 0x0602F03B RID: 192571 RVA: 0x00B23C05 File Offset: 0x00B21E05
		[NullableContext(2)]
		public string GetNoticeUrl()
		{
			EntryJson cdnReturnConfigInfo = this.GetCdnReturnConfigInfo();
			if (cdnReturnConfigInfo == null)
			{
				return null;
			}
			return cdnReturnConfigInfo.NoticeUrl;
		}

		// Token: 0x0602F03C RID: 192572 RVA: 0x00B23C18 File Offset: 0x00B21E18
		[NullableContext(2)]
		public string GetGARUrl()
		{
			EntryJson cdnReturnConfigInfo = this.GetCdnReturnConfigInfo();
			if (cdnReturnConfigInfo == null)
			{
				return null;
			}
			return cdnReturnConfigInfo.GARUrl;
		}

		// Token: 0x0602F03D RID: 192573 RVA: 0x00B23C2C File Offset: 0x00B21E2C
		public bool GetGmIsOpen()
		{
			EntryJson cdnReturnConfigInfo = this.GetCdnReturnConfigInfo();
			return cdnReturnConfigInfo != null && cdnReturnConfigInfo.GmOpen.GetValueOrDefault();
		}

		// Token: 0x0602F03E RID: 192574 RVA: 0x00B23C50 File Offset: 0x00B21E50
		public bool GetRptIsOpen()
		{
			EntryJson cdnReturnConfigInfo = this.GetCdnReturnConfigInfo();
			return ((cdnReturnConfigInfo != null) ? cdnReturnConfigInfo.RptOpen : null).GetValueOrDefault(true);
		}

		// Token: 0x0602F03F RID: 192575 RVA: 0x00B23C80 File Offset: 0x00B21E80
		public bool IsUseThreadCheck()
		{
			EntryJson cdnReturnConfigInfo = this.GetCdnReturnConfigInfo();
			return cdnReturnConfigInfo != null && cdnReturnConfigInfo.AsyncCheck.GetValueOrDefault();
		}

		// Token: 0x0602F040 RID: 192576 RVA: 0x00B23CA4 File Offset: 0x00B21EA4
		public bool IsUseNewHttpTimer()
		{
			EntryJson cdnReturnConfigInfo = this.GetCdnReturnConfigInfo();
			return cdnReturnConfigInfo != null && cdnReturnConfigInfo.NewHttpTimer.GetValueOrDefault();
		}

		// Token: 0x0602F041 RID: 192577 RVA: 0x00B23CC8 File Offset: 0x00B21EC8
		public bool IsUseNewHttpApi()
		{
			EntryJson cdnReturnConfigInfo = this.GetCdnReturnConfigInfo();
			return cdnReturnConfigInfo != null && cdnReturnConfigInfo.NewHttpApi.GetValueOrDefault();
		}

		// Token: 0x0602F042 RID: 192578 RVA: 0x00B23CEC File Offset: 0x00B21EEC
		public bool GetIosAuditFirstDownloadTip()
		{
			string a = KuroApplication.IniPlatformName();
			if (a != "IOS" && a != "Mac")
			{
				return false;
			}
			EntryJson cdnReturnConfigInfo = this.GetCdnReturnConfigInfo();
			return cdnReturnConfigInfo != null && cdnReturnConfigInfo.IosAuditFirstDownloadTip.GetValueOrDefault();
		}

		// Token: 0x0602F043 RID: 192579 RVA: 0x00B23D34 File Offset: 0x00B21F34
		public bool GetIosAuditFirstDownloadTipWithSkip()
		{
			string a = KuroApplication.IniPlatformName();
			if (a != "IOS" && a != "Mac")
			{
				return false;
			}
			bool flag = false;
			UKuroVariableFunctionLibrary.GetBoolValue("IosAuditNeedHotPatch", ref flag);
			return !flag && this.GetIosAuditFirstDownloadTip();
		}

		// Token: 0x0602F044 RID: 192580 RVA: 0x00B23D7D File Offset: 0x00B21F7D
		[return: Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Dictionary<string, string> GetSdkEnvironment()
		{
			EntryJson cdnReturnConfigInfo = this.GetCdnReturnConfigInfo();
			if (cdnReturnConfigInfo == null)
			{
				return null;
			}
			return cdnReturnConfigInfo.SDKEnvironment;
		}

		// Token: 0x0602F045 RID: 192581 RVA: 0x00B23D90 File Offset: 0x00B21F90
		public string GetMixUri()
		{
			EntryJson cdnReturnConfigInfo = this.GetCdnReturnConfigInfo();
			if (cdnReturnConfigInfo == null)
			{
				return "";
			}
			return cdnReturnConfigInfo.MixUri ?? "";
		}

		// Token: 0x0602F046 RID: 192582 RVA: 0x00B23DBC File Offset: 0x00B21FBC
		public string GetResUri()
		{
			EntryJson cdnReturnConfigInfo = this.GetCdnReturnConfigInfo();
			if (cdnReturnConfigInfo == null)
			{
				return "";
			}
			return cdnReturnConfigInfo.ResUri ?? "";
		}

		// Token: 0x0602F047 RID: 192583 RVA: 0x00B23DE8 File Offset: 0x00B21FE8
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ILoginServersData> GetLoginServers()
		{
			EntryJson cdnReturnConfigInfo = this.GetCdnReturnConfigInfo();
			if (cdnReturnConfigInfo == null)
			{
				return null;
			}
			return cdnReturnConfigInfo.LoginServers;
		}

		// Token: 0x0602F048 RID: 192584 RVA: 0x00B23DFC File Offset: 0x00B21FFC
		[return: Nullable(2)]
		public ILoginServersData GetLoginServerById(string serverId)
		{
			List<ILoginServersData> loginServers = this.GetLoginServers();
			if (loginServers != null)
			{
				int count = loginServers.Count;
				for (int i = 0; i < count; i++)
				{
					if (serverId == loginServers[i].id)
					{
						return loginServers[i];
					}
				}
			}
			return null;
		}

		// Token: 0x0602F049 RID: 192585 RVA: 0x00B23E43 File Offset: 0x00B22043
		[NullableContext(2)]
		public IGachaUrl GetGachaUrl()
		{
			EntryJson cdnReturnConfigInfo = this.GetCdnReturnConfigInfo();
			if (cdnReturnConfigInfo == null)
			{
				return null;
			}
			return cdnReturnConfigInfo.GachaUrl;
		}

		// Token: 0x0602F04A RID: 192586 RVA: 0x00B23E56 File Offset: 0x00B22056
		[NullableContext(2)]
		public IFeedBackData GetFeedBackUrl()
		{
			return null;
		}

		// Token: 0x0602F04B RID: 192587 RVA: 0x00B23E59 File Offset: 0x00B22059
		[NullableContext(2)]
		public IPrivateServersData GetPrivateServers()
		{
			EntryJson cdnReturnConfigInfo = this.GetCdnReturnConfigInfo();
			if (cdnReturnConfigInfo == null)
			{
				return null;
			}
			return cdnReturnConfigInfo.PrivateServers;
		}

		// Token: 0x0602F04C RID: 192588 RVA: 0x00B23E6C File Offset: 0x00B2206C
		public string GetPublicValue(TPublicConfigKey key)
		{
			return this.GetPublicValue(key.ToEnumString());
		}

		// Token: 0x0602F04D RID: 192589 RVA: 0x00B23E7C File Offset: 0x00B2207C
		public string GetPublicValue(string key)
		{
			if (!Singleton<BaseConfigModel>.Instance.PublicConfigLoaded)
			{
				TArray<string> tarray = UKuroStaticLibrary.LoadFileToStringArray(BaseDefine.GetPublicConfigPath());
				for (int i = 0; i < tarray.Num(); i++)
				{
					string[] array = tarray.Get(i).Split('=', StringSplitOptions.None);
					Singleton<BaseConfigModel>.Instance.BaseConfig[array[0]] = array[1];
				}
				Singleton<BaseConfigModel>.Instance.PublicConfigLoaded = true;
			}
			string text;
			if (!Singleton<BaseConfigModel>.Instance.BaseConfig.TryGetValue(key, out text))
			{
				return "";
			}
			string text2 = (text != null) ? text.Trim() : null;
			if (string.IsNullOrEmpty(text2))
			{
				return "";
			}
			return text2;
		}

		// Token: 0x0602F04E RID: 192590 RVA: 0x00B23F1C File Offset: 0x00B2211C
		private unsafe string BuildHttp(string http)
		{
			string packageConfigOrDefault = this.GetPackageConfigOrDefault(TBuildInfoKey.Stream, null);
			string item = KuroApplication.IsWithEditor() ? "editor" : "pack";
			string appReleaseType = KuroApplication.GetAppReleaseType();
			string item2 = (this.GetPublicValue(TPublicConfigKey.UseSDK) == "1") ? "sdkon" : "sdkoff";
			string appInternalUseType = UKuroLauncherLibrary.GetAppInternalUseType();
			string buildHttpGameVersion = this.GetBuildHttpGameVersion();
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "包构建参数";
			<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("branch", packageConfigOrDefault);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("platform", item);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("edition", appReleaseType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("sdk", item2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("internalUseType", appInternalUseType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("version", buildHttpGameVersion);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
			string publicValue = this.GetPublicValue(TPublicConfigKey.UrlPath);
			string text = http + "/" + publicValue + "/index.json";
			LauncherLog instance2 = Singleton<LauncherLog>.Instance;
			string message2 = "创建的cdn1地址";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("newHttp", text);
			instance2.Info(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return text;
		}

		// Token: 0x0602F04F RID: 192591 RVA: 0x00B24071 File Offset: 0x00B22271
		private string GetBuildHttpGameVersion()
		{
			return UKuroLauncherLibrary.GetAppVersion();
		}

		// Token: 0x0602F050 RID: 192592 RVA: 0x00B24078 File Offset: 0x00B22278
		public string GetPackageConfigOrDefault(TBuildInfoKey key, string value = null)
		{
			return this.GetPackageConfigOrDefault(key.ToEnumString(), value);
		}

		// Token: 0x0602F051 RID: 192593 RVA: 0x00B24088 File Offset: 0x00B22288
		public string GetPackageConfigOrDefault(string key, string value = null)
		{
			if (!Singleton<BaseConfigModel>.Instance.ParamsConfigInited)
			{
				string path = UBlueprintPathsLibrary.ProjectConfigDir() + "/Package/ParamsConfig.ini";
				Singleton<BaseConfigModel>.Instance.ParamsConfigInited = this.LoadBuildInfoFromFile(path);
				if (!Singleton<BaseConfigModel>.Instance.ParamsConfigInited)
				{
					Singleton<LauncherLog>.Instance.Error("找不到ParamsConfig文件!", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				this.LoadConfigVersion();
				this.LoadPatchBuildInfo(false);
			}
			string text;
			if (Singleton<BaseConfigModel>.Instance.BuildInfoMap.TryGetValue(key, out text))
			{
				string result;
				if (string.IsNullOrEmpty(text))
				{
					result = value;
					if (value == null)
					{
						return "";
					}
				}
				else
				{
					result = text;
				}
				return result;
			}
			return value ?? "";
		}

		// Token: 0x0602F052 RID: 192594 RVA: 0x00B24128 File Offset: 0x00B22328
		public string GetPackageClientFightConfig()
		{
			string filename = UBlueprintPathsLibrary.ProjectContentDir() + "/Aki/Config/Json/CompareFightData/ClientFightDataInfo.json";
			string text = "";
			UKuroStaticLibrary.LoadFileToString(ref text, filename);
			ClientFightConfigData clientFightConfigData = Json.Decode<ClientFightConfigData>(text, null);
			if (clientFightConfigData != null)
			{
				return clientFightConfigData.clientMd5;
			}
			return "";
		}

		// Token: 0x0602F053 RID: 192595 RVA: 0x00B2416C File Offset: 0x00B2236C
		public void LoadPatchBuildInfo(bool isReload)
		{
			if (KuroApplication.IsWithEditor())
			{
				return;
			}
			string path = UBlueprintPathsLibrary.ProjectContentDir() + "/Aki/ConfigDB/Misc/BuildInfo.txt";
			if (!this.LoadBuildInfoFromFile(path))
			{
				string path2 = UBlueprintPathsLibrary.ProjectContentDir() + "/Aki/ConfigDB/PackageParams.txt";
				this.LoadBuildInfoFromFile(path2);
			}
			string packageConfigOrDefault = this.GetPackageConfigOrDefault(TBuildInfoKey.JSDebugId, null);
			Singleton<LauncherLog>.Instance.SetJsDebugId(packageConfigOrDefault);
		}

		// Token: 0x0602F054 RID: 192596 RVA: 0x00B241C8 File Offset: 0x00B223C8
		private bool LoadBuildInfoFromFile(string path)
		{
			TArray<string> tarray = UKuroStaticLibrary.LoadFileToStringArray(path);
			for (int i = 0; i < tarray.Num(); i++)
			{
				string text = tarray.Get(i);
				string[] array = text.Split('=', StringSplitOptions.None);
				if (array != null && array.Length >= 2)
				{
					Singleton<BaseConfigModel>.Instance.BuildInfoMap[array[0].Trim()] = array[1].Trim();
				}
				else
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "无法解析数据";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("param", text);
					instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}
			return tarray.Num() > 0;
		}

		// Token: 0x0602F055 RID: 192597 RVA: 0x00B2425C File Offset: 0x00B2245C
		public void LoadConfigVersion()
		{
			string path = UBlueprintPathsLibrary.ProjectContentDir() + "/Aki/ConfigDB/Misc/ConfigVersion.txt";
			this.LoadConfigVersionFromFile(path);
		}

		// Token: 0x0602F056 RID: 192598 RVA: 0x00B24284 File Offset: 0x00B22484
		private bool LoadConfigVersionFromFile(string path)
		{
			TArray<string> tarray = UKuroStaticLibrary.LoadFileToStringArray(path);
			for (int i = 0; i < tarray.Num(); i++)
			{
				string text = tarray.Get(i);
				string[] array = text.Split('=', StringSplitOptions.None);
				if (array != null && array.Length >= 2)
				{
					Singleton<BaseConfigModel>.Instance.ConfigVersionMap[array[0].Trim()] = array[1].Trim();
				}
				else
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "无法解析数据";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("param", text);
					instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}
			return tarray.Num() > 0;
		}

		// Token: 0x0602F057 RID: 192599 RVA: 0x00B24316 File Offset: 0x00B22516
		public string GetConfigVersion(TConfigVersionKey key)
		{
			return this.GetConfigVersion(key.ToEnumString());
		}

		// Token: 0x0602F058 RID: 192600 RVA: 0x00B24324 File Offset: 0x00B22524
		public string GetConfigVersion(string key)
		{
			string result;
			if (!Singleton<BaseConfigModel>.Instance.ConfigVersionMap.TryGetValue(key, out result))
			{
				return "";
			}
			return result;
		}

		// Token: 0x0602F059 RID: 192601 RVA: 0x00B2434C File Offset: 0x00B2254C
		public string GetP4Version()
		{
			string packageConfigOrDefault = this.GetPackageConfigOrDefault(TBuildInfoKey.Changelist, null);
			string deviceSaved = Singleton<LauncherStorageLib>.Instance.GetDeviceSaved<string>(ELauncherStorageDeviceKey.PatchP4Version, null);
			RemoteInfo instance = Singleton<RemoteInfo>.Instance;
			string text;
			if (instance == null)
			{
				text = null;
			}
			else
			{
				RemoteVersionConfig newConfig = instance.NewConfig;
				text = ((newConfig != null) ? newConfig.ChangeList : null);
			}
			string text2 = text;
			if (!string.IsNullOrEmpty(deviceSaved))
			{
				return deviceSaved;
			}
			if (string.IsNullOrEmpty(text2) || text2.Length == 0)
			{
				return packageConfigOrDefault;
			}
			return text2;
		}

		// Token: 0x0602F05A RID: 192602 RVA: 0x00B243AC File Offset: 0x00B225AC
		public string GetVersionString()
		{
			string value = "CN";
			if (this.GetPublicValue(TPublicConfigKey.SdkArea) != "CN")
			{
				value = "OS";
			}
			string text = KuroApplication.IniPlatformName();
			if (text == "WinGDK" || text == "XSX")
			{
				text = "Xbox";
			}
			string value2 = text;
			string appReleaseType = KuroApplication.GetAppReleaseType();
			string appChangeList = UKuroLauncherLibrary.GetAppChangeList();
			string text2 = this.GetPackageConfigOrDefault(TBuildInfoKey.PatchVersion, null);
			string deviceSaved = Singleton<LauncherStorageLib>.Instance.GetDeviceSaved<string>(ELauncherStorageDeviceKey.PatchVersion, null);
			RemoteVersionConfig newConfig = Singleton<RemoteInfo>.Instance.NewConfig;
			VersionItem versionItem;
			string text3 = (((newConfig != null) ? newConfig.ResVersions : null) != null && Singleton<RemoteInfo>.Instance.NewConfig.ResVersions.TryGetValue("resource", out versionItem)) ? ((versionItem != null) ? versionItem.Version : null) : null;
			text2 = ((!string.IsNullOrEmpty(deviceSaved)) ? deviceSaved : ((!string.IsNullOrEmpty(text3)) ? text3 : text2));
			string appVersion = UKuroLauncherLibrary.GetAppVersion();
			string p4Version = this.GetP4Version();
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 7);
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted(value2);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted(appReleaseType);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted(appVersion);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted(appChangeList);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted(text2);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted(p4Version);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0401AC70 RID: 109680
		private const string BUILD_INFO_BASE_PACKAGE = "/Package/ParamsConfig.ini";

		// Token: 0x0401AC71 RID: 109681
		private const string BUILD_INFO_PATCH_OVERRIDE_OLD = "/Aki/ConfigDB/PackageParams.txt";

		// Token: 0x0401AC72 RID: 109682
		private const string BUILD_INFO_PATCH_OVERRIDE = "/Aki/ConfigDB/Misc/BuildInfo.txt";

		// Token: 0x0401AC73 RID: 109683
		private const string CONFIG_VERSION_PATCH_OVERRIDE = "/Aki/ConfigDB/Misc/ConfigVersion.txt";
	}
}
