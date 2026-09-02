using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.ResManager.Model
{
	// Token: 0x0200528B RID: 21131
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class ResourceManagerModel : ModelBase<ResourceManagerModel>
	{
		// Token: 0x0603609C RID: 221340 RVA: 0x00D9A520 File Offset: 0x00D98720
		protected override bool OnInit()
		{
			IReadOnlyList<MapBlockInfo> configList = ConfigMapBlockInfoAll.GetConfigList(false);
			if (configList == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.QuestResource, ELogAuthor.HWK, "找不到地块配置", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			foreach (MapBlockInfo mapBlockInfo in configList)
			{
				this.BlockIdToPackName[mapBlockInfo.BlockId] = mapBlockInfo.PakName;
			}
			IReadOnlyList<QuestRefMapBlockConfig> configList2 = ConfigQuestRefMapBlockConfigAll.GetConfigList(false);
			if (configList2 == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.QuestResource, ELogAuthor.HWK, "找不到任务地块引用配置", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			foreach (QuestRefMapBlockConfig questRefMapBlockConfig in configList2)
			{
				this.QuestsRefBlocks[questRefMapBlockConfig.QuestId] = questRefMapBlockConfig.GetMapBlockIdArray();
			}
			return true;
		}

		// Token: 0x0603609D RID: 221341 RVA: 0x00D9A61C File Offset: 0x00D9881C
		public unsafe void FillLoginInfo(int[] quests, ConfirmResourceSceneInfo[] sceneInfos)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.QuestResource;
			ELogAuthor author = ELogAuthor.HWK;
			string message = "填充登录资源信息";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("quests", quests);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("sceneInfos", sceneInfos);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.LoginQuestsInternal.Clear();
			foreach (int item in quests)
			{
				this.LoginQuestsInternal.Add(item);
			}
			this.LoginSceneInfosInternal.Clear();
			this.LoginSceneInfosInternal.AddRange(sceneInfos);
		}

		// Token: 0x17008CF1 RID: 36081
		// (get) Token: 0x0603609E RID: 221342 RVA: 0x00D9A6BF File Offset: 0x00D988BF
		public List<ConfirmResourceSceneInfo> LoginSceneInfos
		{
			get
			{
				return this.LoginSceneInfosInternal;
			}
		}

		// Token: 0x17008CF2 RID: 36082
		// (get) Token: 0x0603609F RID: 221343 RVA: 0x00D9A6C7 File Offset: 0x00D988C7
		public Dictionary<int, string> MapBlockIdToPackName
		{
			get
			{
				return this.BlockIdToPackName;
			}
		}

		// Token: 0x17008CF3 RID: 36083
		// (get) Token: 0x060360A0 RID: 221344 RVA: 0x00D9A6CF File Offset: 0x00D988CF
		public HashSet<int> LoginQuests
		{
			get
			{
				return this.LoginQuestsInternal;
			}
		}

		// Token: 0x060360A1 RID: 221345 RVA: 0x00D9A6D8 File Offset: 0x00D988D8
		public void SetBlockDownloadState(int blockId, bool state)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.QuestResource;
			ELogAuthor author = ELogAuthor.HWK;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 2);
			defaultInterpolatedStringHandler.AppendLiteral("设置地块下载状态: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(blockId);
			defaultInterpolatedStringHandler.AppendLiteral(" => ");
			defaultInterpolatedStringHandler.AppendFormatted<bool>(state);
			instance.Info(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			this.BlockDownloadState[blockId] = state;
		}

		// Token: 0x060360A2 RID: 221346 RVA: 0x00D9A744 File Offset: 0x00D98944
		public bool GetBlockDownloadState(int blockId)
		{
			bool result;
			if (!this.BlockDownloadState.TryGetValue(blockId, out result))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.QuestResource;
				ELogAuthor author = ELogAuthor.HWK;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 1);
				defaultInterpolatedStringHandler.AppendLiteral("未知或未分包的地块ID: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(blockId);
				instance.Warn(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return true;
			}
			return result;
		}

		// Token: 0x060360A3 RID: 221347 RVA: 0x00D9A7A0 File Offset: 0x00D989A0
		protected override bool OnClear()
		{
			return true;
		}

		// Token: 0x060360A4 RID: 221348 RVA: 0x00D9A7A3 File Offset: 0x00D989A3
		protected override bool OnLeaveLevel()
		{
			return true;
		}

		// Token: 0x060360A5 RID: 221349 RVA: 0x00D9A7A6 File Offset: 0x00D989A6
		protected override bool OnChangeMode()
		{
			return true;
		}

		// Token: 0x0401F0E9 RID: 127209
		private readonly Dictionary<int, string> BlockIdToPackName = new Dictionary<int, string>();

		// Token: 0x0401F0EA RID: 127210
		private readonly HashSet<int> LoginQuestsInternal = new HashSet<int>();

		// Token: 0x0401F0EB RID: 127211
		private readonly List<ConfirmResourceSceneInfo> LoginSceneInfosInternal = new List<ConfirmResourceSceneInfo>();

		// Token: 0x0401F0EC RID: 127212
		private readonly Dictionary<int, bool> BlockDownloadState = new Dictionary<int, bool>();

		// Token: 0x0401F0ED RID: 127213
		public readonly Dictionary<int, int[]> QuestsRefBlocks = new Dictionary<int, int[]>();

		// Token: 0x0401F0EE RID: 127214
		public readonly HashSet<int> BlockNeedReOpenMap = new HashSet<int>();
	}
}
