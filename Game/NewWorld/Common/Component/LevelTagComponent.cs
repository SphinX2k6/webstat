using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Common.Component
{
	// Token: 0x020048C4 RID: 18628
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelTagComponent : BaseTagComponent
	{
		// Token: 0x170082C6 RID: 33478
		// (get) Token: 0x0603092A RID: 198954 RVA: 0x00BF10E0 File Offset: 0x00BEF2E0
		// (set) Token: 0x0603092B RID: 198955 RVA: 0x00BF10E8 File Offset: 0x00BEF2E8
		public long NotifyLock
		{
			get
			{
				return this.NotifyLockInternal;
			}
			set
			{
				if (value == this.NotifyLockInternal)
				{
					return;
				}
				this.NotifyLockInternal = value;
				if (this.NotifyLockInternal == 0L)
				{
					this.NotifyTagChanged();
				}
			}
		}

		// Token: 0x0603092C RID: 198956 RVA: 0x00BF110C File Offset: 0x00BEF30C
		[NullableContext(2)]
		protected override bool OnInitData(IEntityArgs args = null)
		{
			base.OnInitData(args);
			this.OldCountMap.Clear();
			this.CreatureDataComponent = base.Entity.GetComponent<CreatureDataComponent>();
			if (this.CreatureDataComponent != null)
			{
				this.CreatureDataComponent.GetPbDataId();
				this.CreatureDataComponent.GetCreatureDataId();
				foreach (int tagId in this.CreatureDataComponent.GetEntityCommonTags())
				{
					this.AddServerTagInternal(tagId);
				}
			}
			return true;
		}

		// Token: 0x0603092D RID: 198957 RVA: 0x00BF11AC File Offset: 0x00BEF3AC
		protected unsafe override bool OnStart()
		{
			base.OnStart();
			CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
			if (component != null && component.IsConcealed)
			{
				this.AddTag(new int?(GameplayTagDefine.EGameplayTagId["物体.表现.隐匿"]));
			}
			List<int> list;
			if (component == null)
			{
				list = null;
			}
			else
			{
				ModelComponent modelComponent = component.GetModelComponent();
				list = ((modelComponent != null) ? modelComponent.PerformanceTags : null);
			}
			List<int> list2 = list;
			if (list2 != null)
			{
				foreach (int num in list2)
				{
					if (!GameplayTagUtils.IsChildTag(num, GameplayTagDefine.EGameplayTagId["关卡.Common.表现"]))
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Entity;
						ELogAuthor author = ELogAuthor.ZYL;
						string message = "实体配置了非【关卡.Common.表现】子Tag的客户端模型表现Tag，请检查配置";
						<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
						ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
						string item = "pbDataId";
						CreatureDataComponent creatureDataComponent = this.CreatureDataComponent;
						ptr = new ValueTuple<string, object>(item, (creatureDataComponent != null) ? new int?(creatureDataComponent.GetPbDataId()) : null);
						ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
						string item2 = "creatureDataId";
						CreatureDataComponent creatureDataComponent2 = this.CreatureDataComponent;
						ptr2 = new ValueTuple<string, object>(item2, (creatureDataComponent2 != null) ? new long?(creatureDataComponent2.GetCreatureDataId()) : null);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("tagId", num);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("tagName", GameplayTagUtils.GetNameByTagId(num));
						instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
					}
					else
					{
						this.AddTag(new int?(num));
					}
				}
			}
			return true;
		}

		// Token: 0x0603092E RID: 198958 RVA: 0x00BF1360 File Offset: 0x00BEF560
		protected unsafe override void OnTick(float delta)
		{
			if (this.NotifyLock != 0L)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Entity;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "Notifylock在Tick结束时不为0";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
				string item = "pbDataId";
				CreatureDataComponent creatureDataComponent = this.CreatureDataComponent;
				ptr = new ValueTuple<string, object>(item, (creatureDataComponent != null) ? new int?(creatureDataComponent.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("LockCount", this.NotifyLock);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.NotifyLock = 0L;
			}
		}

		// Token: 0x0603092F RID: 198959 RVA: 0x00BF1400 File Offset: 0x00BEF600
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public string[] GetTagNames()
		{
			if (!GlobalData.IsPlayInEditor)
			{
				return null;
			}
			List<string> list = new List<string>();
			foreach (int tagId in this.GetTagIds())
			{
				string nameByTagId = GameplayTagUtils.GetNameByTagId(tagId);
				if (nameByTagId != null && !list.Contains(nameByTagId))
				{
					list.Add(nameByTagId);
				}
			}
			return list.ToArray();
		}

		// Token: 0x06030930 RID: 198960 RVA: 0x00BF1474 File Offset: 0x00BEF674
		public bool ContainsTag(FGameplayTag tag)
		{
			int num = tag.TagId();
			return num != 0 && this.HasTag(num);
		}

		// Token: 0x06030931 RID: 198961 RVA: 0x00BF1494 File Offset: 0x00BEF694
		public bool ContainsTagByName(string tagName)
		{
			int tagIdByName = GameplayTagUtils.GetTagIdByName(tagName);
			return tagIdByName != 0 && this.HasTag(tagIdByName);
		}

		// Token: 0x06030932 RID: 198962 RVA: 0x00BF14B4 File Offset: 0x00BEF6B4
		public override void AddTag(int? tagId)
		{
			long notifyLock = this.NotifyLock;
			this.NotifyLock = notifyLock + 1L;
			base.AddTag(tagId);
			notifyLock = this.NotifyLock;
			this.NotifyLock = notifyLock - 1L;
		}

		// Token: 0x06030933 RID: 198963 RVA: 0x00BF14EC File Offset: 0x00BEF6EC
		public override bool RemoveTag(int? tagId)
		{
			long notifyLock = this.NotifyLock;
			this.NotifyLock = notifyLock + 1L;
			bool result = base.RemoveTag(tagId);
			notifyLock = this.NotifyLock;
			this.NotifyLock = notifyLock - 1L;
			return result;
		}

		// Token: 0x06030934 RID: 198964 RVA: 0x00BF1524 File Offset: 0x00BEF724
		public void ChangeLocalLevelTag(int tagAdd, int tagRemove)
		{
			long notifyLock = this.NotifyLock;
			this.NotifyLock = notifyLock + 1L;
			this.RemoveTag(new int?(tagRemove));
			this.AddTag(new int?(tagAdd));
			notifyLock = this.NotifyLock;
			this.NotifyLock = notifyLock - 1L;
		}

		// Token: 0x06030935 RID: 198965 RVA: 0x00BF156C File Offset: 0x00BEF76C
		private void AddServerTagInternal(int tagId)
		{
			if (this.HasTag(tagId))
			{
				return;
			}
			if (GameplayTagUtils.GetNameByTagId(tagId) == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Entity;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "要添加的tagId找不到对应的gameplayTag";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tagId", tagId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			long notifyLock = this.NotifyLock;
			this.NotifyLock = notifyLock + 1L;
			this.TagContainer.AddExactTag(ETagChannel.LevelServer, tagId);
			notifyLock = this.NotifyLock;
			this.NotifyLock = notifyLock - 1L;
		}

		// Token: 0x06030936 RID: 198966 RVA: 0x00BF15E8 File Offset: 0x00BEF7E8
		private void RemoveServerTagInternal(int tagId)
		{
			if (this.TagContainer.GetRawTagCount(ETagChannel.LevelServer, tagId) <= 0)
			{
				return;
			}
			long notifyLock = this.NotifyLock;
			this.NotifyLock = notifyLock + 1L;
			this.TagContainer.RemoveExactTag(ETagChannel.LevelServer, tagId);
			notifyLock = this.NotifyLock;
			this.NotifyLock = notifyLock - 1L;
		}

		// Token: 0x06030937 RID: 198967 RVA: 0x00BF1638 File Offset: 0x00BEF838
		public void SyncTagsFromServer(IList<CommonTagData> tags)
		{
			foreach (CommonTagData commonTagData in tags)
			{
				int tagId = commonTagData.TagId;
				if (!commonTagData.IsAdd)
				{
					this.RemoveServerTagInternal(tagId);
				}
				else
				{
					this.AddServerTagInternal(tagId);
				}
			}
		}

		// Token: 0x06030938 RID: 198968 RVA: 0x00BF1698 File Offset: 0x00BEF898
		public void AddServerTagByIdLocal(int tagId, string reason)
		{
			this.AddServerTagInternal(tagId);
		}

		// Token: 0x06030939 RID: 198969 RVA: 0x00BF16A1 File Offset: 0x00BEF8A1
		public void RemoveServerTagByIdLocal(int tagId, string reason)
		{
			this.RemoveServerTagInternal(tagId);
		}

		// Token: 0x0603093A RID: 198970 RVA: 0x00BF16AC File Offset: 0x00BEF8AC
		public void NotifyTagChanged()
		{
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			foreach (int num in this.OldCountMap.Keys)
			{
				int num2 = this.OldCountMap[num];
				int tagCount = base.GetTagCount(num);
				if (num2 > 0 && tagCount <= 0)
				{
					list2.Add(num);
				}
				else if (num2 <= 0 && tagCount > 0)
				{
					list.Add(num);
				}
			}
			this.OldCountMap.Clear();
			bool flag = false;
			if (list.Count > 0)
			{
				foreach (int tagId in list)
				{
					if (this.IsTagShouldNotify(tagId))
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag && list2.Count > 0)
			{
				foreach (int tagId2 in list2)
				{
					if (this.IsTagShouldNotify(tagId2))
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				Singleton<EventSystem>.Instance.EmitWithTarget<IReadOnlyList<int>, IReadOnlyList<int>>(base.Entity, EEventName.OnLevelTagChanged, list, list2);
			}
		}

		// Token: 0x0603093B RID: 198971 RVA: 0x00BF1814 File Offset: 0x00BEFA14
		public IEnumerable<int> GetTagIds()
		{
			LevelTagComponent.<GetTagIds>d__22 <GetTagIds>d__ = new LevelTagComponent.<GetTagIds>d__22(-2);
			<GetTagIds>d__.<>4__this = this;
			return <GetTagIds>d__;
		}

		// Token: 0x0603093C RID: 198972 RVA: 0x00BF1824 File Offset: 0x00BEFA24
		protected override void OnAnyTagChanged(int tagId, int newCount, int oldCount, int exactTagId)
		{
			if (tagId == 0 || oldCount == newCount)
			{
				return;
			}
			base.OnAnyTagChanged(tagId, newCount, oldCount, exactTagId);
			if (!this.OldCountMap.ContainsKey(tagId))
			{
				this.OldCountMap[tagId] = oldCount;
			}
		}

		// Token: 0x0603093D RID: 198973 RVA: 0x00BF1854 File Offset: 0x00BEFA54
		private bool IsTagShouldNotify(int tagId)
		{
			foreach (int tagB in LevelTagComponent.shouldNotifyTagType)
			{
				if (GameplayTagUtils.IsChildTag(tagId, tagB))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603093E RID: 198974 RVA: 0x00BF1888 File Offset: 0x00BEFA88
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			LevelTagComponent levelTagComponent = (LevelTagComponent)componentTemplate;
			if (base.CanResetComponentProperty("CreatureDataComponent"))
			{
				if (levelTagComponent.CreatureDataComponent == null)
				{
					this.CreatureDataComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComponent), "CreatureDataComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("OldCountMap") && levelTagComponent.OldCountMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, int>>(this.OldCountMap), "OldCountMap"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("NotifyLockInternal"))
			{
				this.NotifyLockInternal = levelTagComponent.NotifyLockInternal;
			}
			return true;
		}

		// Token: 0x0401BE9C RID: 114332
		[StaticVariableRuleIgnore]
		public static readonly int[] shouldNotifyTagType = new int[]
		{
			GameplayTagDefine.EGameplayTagId["物体"],
			GameplayTagDefine.EGameplayTagId["关卡"]
		};

		// Token: 0x0401BE9D RID: 114333
		[Nullable(2)]
		private CreatureDataComponent CreatureDataComponent;

		// Token: 0x0401BE9E RID: 114334
		private readonly Dictionary<int, int> OldCountMap = new Dictionary<int, int>();

		// Token: 0x0401BE9F RID: 114335
		private long NotifyLockInternal;
	}
}
