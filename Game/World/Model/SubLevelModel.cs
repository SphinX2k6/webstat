using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.World.Model
{
	// Token: 0x020046D6 RID: 18134
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SubLevelModel : ModelBase<SubLevelModel>
	{
		// Token: 0x0602F27F RID: 193151 RVA: 0x00B2C4A0 File Offset: 0x00B2A6A0
		protected override bool OnLeaveLevel()
		{
			List<string> list = new List<string>();
			foreach (string item in this.PreloadLevelMap.Keys)
			{
				list.Add(item);
			}
			foreach (string item2 in this.SubLevelMap.Keys)
			{
				list.Add(item2);
			}
			foreach (string path in list)
			{
				this.RemoveSubLevel(path, true);
			}
			list.Clear();
			this.IsInSubLevelSwitchingInternal = false;
			this.IsBlockingInputInSwitchingInternal = false;
			return true;
		}

		// Token: 0x0602F280 RID: 193152 RVA: 0x00B2C59C File Offset: 0x00B2A79C
		public void SetSubLevelSwitching(bool bBlockInput)
		{
			this.IsInSubLevelSwitchingInternal = true;
			this.IsBlockingInputInSwitchingInternal = bBlockInput;
		}

		// Token: 0x0602F281 RID: 193153 RVA: 0x00B2C5AC File Offset: 0x00B2A7AC
		public void UnsetSubLevelSwitching()
		{
			this.IsInSubLevelSwitchingInternal = false;
			this.IsBlockingInputInSwitchingInternal = false;
		}

		// Token: 0x0602F282 RID: 193154 RVA: 0x00B2C5BC File Offset: 0x00B2A7BC
		public bool IsInSubLevelSwitching()
		{
			return this.IsInSubLevelSwitchingInternal;
		}

		// Token: 0x0602F283 RID: 193155 RVA: 0x00B2C5C4 File Offset: 0x00B2A7C4
		public bool IsInSubLevelSwitchingAndBlockingInput()
		{
			return this.IsInSubLevelSwitchingInternal && this.IsBlockingInputInSwitchingInternal;
		}

		// Token: 0x0602F284 RID: 193156 RVA: 0x00B2C5D6 File Offset: 0x00B2A7D6
		public Dictionary<string, SubLevel> GetAllPreloadSubLevels()
		{
			return this.PreloadLevelMap;
		}

		// Token: 0x0602F285 RID: 193157 RVA: 0x00B2C5DE File Offset: 0x00B2A7DE
		public Dictionary<string, SubLevel> GetAllSubLevels()
		{
			return this.SubLevelMap;
		}

		// Token: 0x0602F286 RID: 193158 RVA: 0x00B2C5E6 File Offset: 0x00B2A7E6
		public Dictionary<string, SubLevel> GetAllUnloadSubLevels()
		{
			return this.UnloadLevelMap;
		}

		// Token: 0x0602F287 RID: 193159 RVA: 0x00B2C5F0 File Offset: 0x00B2A7F0
		[return: Nullable(2)]
		public SubLevel AddPreloadSubLevel(string path)
		{
			if (this.PreloadLevelMap.ContainsKey(path))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.World;
				ELogAuthor author = ELogAuthor.LFJW;
				string message = "[GameModeModel.AddPreloadSubLevel] 重复添加预加载的Level，因为存在于this.PreloadLevelMap中";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", path);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			if (this.SubLevelMap.ContainsKey(path))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.World;
				ELogAuthor author2 = ELogAuthor.LFJW;
				string message2 = "[GameModeModel.AddPreloadSubLevel] 重复添加预加载Level，因为存在于SubLevelMap中";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Path", path);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return null;
			}
			SubLevel subLevel = new SubLevel(path, false);
			this.PreloadLevelMap[path] = subLevel;
			return subLevel;
		}

		// Token: 0x0602F288 RID: 193160 RVA: 0x00B2C67F File Offset: 0x00B2A87F
		public bool RemovePreloadSubLevel(string path)
		{
			return this.PreloadLevelMap.Remove(path);
		}

		// Token: 0x0602F289 RID: 193161 RVA: 0x00B2C690 File Offset: 0x00B2A890
		[return: Nullable(2)]
		public SubLevel GetPreloadSubLevel(string path)
		{
			SubLevel result;
			if (!this.PreloadLevelMap.TryGetValue(path, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0602F28A RID: 193162 RVA: 0x00B2C6B0 File Offset: 0x00B2A8B0
		[return: Nullable(2)]
		public SubLevel GetPreloadOrLoadedSubLevel(string path)
		{
			SubLevel result;
			if (this.PreloadLevelMap.TryGetValue(path, out result))
			{
				return result;
			}
			if (!this.SubLevelMap.TryGetValue(path, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0602F28B RID: 193163 RVA: 0x00B2C6E4 File Offset: 0x00B2A8E4
		[return: Nullable(2)]
		public SubLevel GetSubLevel(string path)
		{
			SubLevel result;
			if (!this.SubLevelMap.TryGetValue(path, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0602F28C RID: 193164 RVA: 0x00B2C704 File Offset: 0x00B2A904
		[return: Nullable(2)]
		public SubLevel AddSubLevel(string path, bool visibleAfterLoad)
		{
			if (this.SubLevelMap.ContainsKey(path))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.World;
				ELogAuthor author = ELogAuthor.LFJW;
				string message = "[GameModeModel.AddSubLevel] 重复添加子关卡。";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", path);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			SubLevel subLevel = new SubLevel(path, visibleAfterLoad);
			this.SubLevelMap[path] = subLevel;
			return subLevel;
		}

		// Token: 0x0602F28D RID: 193165 RVA: 0x00B2C760 File Offset: 0x00B2A960
		[NullableContext(0)]
		public UniTask<bool> RemoveSubLevel([Nullable(1)] string path, bool bForceRemove = false)
		{
			SubLevelModel.<RemoveSubLevel>d__19 <RemoveSubLevel>d__;
			<RemoveSubLevel>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RemoveSubLevel>d__.<>4__this = this;
			<RemoveSubLevel>d__.path = path;
			<RemoveSubLevel>d__.bForceRemove = bForceRemove;
			<RemoveSubLevel>d__.<>1__state = -1;
			<RemoveSubLevel>d__.<>t__builder.Start<SubLevelModel.<RemoveSubLevel>d__19>(ref <RemoveSubLevel>d__);
			return <RemoveSubLevel>d__.<>t__builder.Task;
		}

		// Token: 0x0602F28E RID: 193166 RVA: 0x00B2C7B4 File Offset: 0x00B2A9B4
		public void MovePreloadSubLevelToSubLevel(string path)
		{
			SubLevel preloadSubLevel = this.GetPreloadSubLevel(path);
			if (preloadSubLevel == null)
			{
				return;
			}
			this.RemovePreloadSubLevel(path);
			this.AddSubLevelInstance(preloadSubLevel);
		}

		// Token: 0x0602F28F RID: 193167 RVA: 0x00B2C7E0 File Offset: 0x00B2A9E0
		private bool AddSubLevelInstance(SubLevel level)
		{
			if (this.SubLevelMap.ContainsKey(level.Path))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.World;
				ELogAuthor author = ELogAuthor.LFJW;
				string message = "[GameModeModel.AddSubLevelInstance] 重复添加子关卡。";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", level.Path);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			this.SubLevelMap[level.Path] = level;
			return true;
		}

		// Token: 0x0602F290 RID: 193168 RVA: 0x00B2C840 File Offset: 0x00B2AA40
		[return: Nullable(2)]
		public SubLevel GetUnloadSubLevel(string path)
		{
			SubLevel result;
			if (!this.UnloadLevelMap.TryGetValue(path, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0602F291 RID: 193169 RVA: 0x00B2C860 File Offset: 0x00B2AA60
		public void AddUnloadSubLevel(string path, SubLevel subLevel)
		{
			this.UnloadLevelMap[path] = subLevel;
		}

		// Token: 0x0602F292 RID: 193170 RVA: 0x00B2C86F File Offset: 0x00B2AA6F
		public bool RemoveUnloadSubLevel(string path)
		{
			return this.UnloadLevelMap.Remove(path);
		}

		// Token: 0x0401ADC3 RID: 110019
		private readonly Dictionary<string, SubLevel> PreloadLevelMap = new Dictionary<string, SubLevel>();

		// Token: 0x0401ADC4 RID: 110020
		private readonly Dictionary<string, SubLevel> SubLevelMap = new Dictionary<string, SubLevel>();

		// Token: 0x0401ADC5 RID: 110021
		private readonly Dictionary<string, SubLevel> UnloadLevelMap = new Dictionary<string, SubLevel>();

		// Token: 0x0401ADC6 RID: 110022
		private bool IsInSubLevelSwitchingInternal;

		// Token: 0x0401ADC7 RID: 110023
		private bool IsBlockingInputInSwitchingInternal;
	}
}
