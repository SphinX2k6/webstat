using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200639D RID: 25501
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeActionData
	{
		// Token: 0x06040061 RID: 262241 RVA: 0x01068F94 File Offset: 0x01067194
		public unsafe void SetChooseData(RoverRogueChooseData proto)
		{
			int bindId = proto.BindId;
			RoverlikeChooseData roverlikeChooseData;
			this.ChooseDataMap.TryGetValue(bindId, out roverlikeChooseData);
			RoverlikeChooseData roverlikeChooseData2 = new RoverlikeChooseData(proto);
			if (roverlikeChooseData != null)
			{
				roverlikeChooseData2.SubViewIncId = roverlikeChooseData.SubViewIncId;
				int num = -1;
				for (int i = 0; i < this.ChooseDataQueue.Count; i++)
				{
					if (this.ChooseDataQueue[i].BindId == bindId)
					{
						num = i;
						break;
					}
				}
				if (num != -1)
				{
					this.ChooseDataQueue[num] = roverlikeChooseData2;
				}
				this.ChooseDataMap[bindId] = roverlikeChooseData2;
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Roverlike;
				ELogAuthor author = ELogAuthor.YYZ;
				string message = "[俯视角肉鸽] 更新ChooseData";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("BindId", bindId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				ControllerBase<RoverlikeController>.Instance.UpdateActionSubView(roverlikeChooseData2.SubViewIncId);
				return;
			}
			this.ChooseDataQueue.Add(roverlikeChooseData2);
			this.ChooseDataMap[bindId] = roverlikeChooseData2;
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Roverlike;
			ELogAuthor author2 = ELogAuthor.YYZ;
			string message2 = "[俯视角肉鸽] 新增ChooseData";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Index", this.ChooseDataQueue.Count - 1);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BindId", bindId);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			ERoverActionSubViewType type = RoverlikeActionSubViewFactory.ServerTypeToSubViewType(roverlikeChooseData2.Type);
			int subViewIncId = ControllerBase<RoverlikeController>.Instance.OpenActionSubView(type, roverlikeChooseData2.BindId);
			roverlikeChooseData2.SubViewIncId = subViewIncId;
		}

		// Token: 0x06040062 RID: 262242 RVA: 0x0106911C File Offset: 0x0106731C
		public unsafe void RemoveChooseData(int bindId)
		{
			RoverlikeChooseData roverlikeChooseData;
			if (!this.ChooseDataMap.TryGetValue(bindId, out roverlikeChooseData))
			{
				return;
			}
			roverlikeChooseData.IsSelect = true;
			if (roverlikeChooseData.SubViewIncId > 0)
			{
				ControllerBase<RoverlikeController>.Instance.FinishActionSubView(roverlikeChooseData.SubViewIncId);
			}
			int num = -1;
			for (int i = 0; i < this.ChooseDataQueue.Count; i++)
			{
				if (this.ChooseDataQueue[i].BindId == bindId)
				{
					num = i;
					break;
				}
			}
			if (num != -1)
			{
				this.ChooseDataQueue.RemoveAt(num);
			}
			this.ChooseDataMap.Remove(bindId);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Roverlike;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "[俯视角肉鸽] 删除ChooseData";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Index", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BindId", bindId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x06040063 RID: 262243 RVA: 0x01069208 File Offset: 0x01067408
		[NullableContext(2)]
		public RoverlikeChooseData GetChooseDataByBindId(int bindId)
		{
			RoverlikeChooseData result;
			if (this.ChooseDataMap.TryGetValue(bindId, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x06040064 RID: 262244 RVA: 0x01069228 File Offset: 0x01067428
		public List<RoverlikeChooseData> GetAllChooseData()
		{
			return new List<RoverlikeChooseData>(this.ChooseDataQueue);
		}

		// Token: 0x06040065 RID: 262245 RVA: 0x01069235 File Offset: 0x01067435
		[NullableContext(2)]
		public RoverlikeChooseData GetCurrentChooseData()
		{
			if (this.ChooseDataQueue.Count == 0)
			{
				return null;
			}
			return this.ChooseDataQueue[this.ChooseDataQueue.Count - 1];
		}

		// Token: 0x06040066 RID: 262246 RVA: 0x01069260 File Offset: 0x01067460
		public bool IsCurrentChooseData(int bindId)
		{
			RoverlikeChooseData currentChooseData = this.GetCurrentChooseData();
			return currentChooseData != null && currentChooseData.BindId == bindId;
		}

		// Token: 0x06040067 RID: 262247 RVA: 0x01069282 File Offset: 0x01067482
		public void Clear()
		{
			this.ChooseDataQueue.Clear();
			this.ChooseDataMap.Clear();
			this.ObtainParamQueue.Clear();
		}

		// Token: 0x06040068 RID: 262248 RVA: 0x010692A5 File Offset: 0x010674A5
		public void PushObtainParam(IRoverlikeGeneralObtainParam param)
		{
			this.ObtainParamQueue.Add(param);
		}

		// Token: 0x06040069 RID: 262249 RVA: 0x010692B3 File Offset: 0x010674B3
		[NullableContext(2)]
		public IRoverlikeGeneralObtainParam PopObtainParam()
		{
			if (this.ObtainParamQueue.Count == 0)
			{
				return null;
			}
			IRoverlikeGeneralObtainParam result = this.ObtainParamQueue[0];
			this.ObtainParamQueue.RemoveAt(0);
			return result;
		}

		// Token: 0x0604006A RID: 262250 RVA: 0x010692DC File Offset: 0x010674DC
		public bool HasObtainParam()
		{
			return this.ObtainParamQueue.Count > 0;
		}

		// Token: 0x04023F2B RID: 147243
		private readonly List<RoverlikeChooseData> ChooseDataQueue = new List<RoverlikeChooseData>();

		// Token: 0x04023F2C RID: 147244
		private readonly Dictionary<int, RoverlikeChooseData> ChooseDataMap = new Dictionary<int, RoverlikeChooseData>();

		// Token: 0x04023F2D RID: 147245
		private readonly List<IRoverlikeGeneralObtainParam> ObtainParamQueue = new List<IRoverlikeGeneralObtainParam>();
	}
}
