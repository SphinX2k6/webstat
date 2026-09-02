using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiNavigation.Struct;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C8F RID: 19599
	[NullableContext(1)]
	[Nullable(0)]
	public class NavigationGroup
	{
		// Token: 0x0603314E RID: 209230 RVA: 0x00CCB28B File Offset: 0x00CC948B
		public void AddListener(TsUiNavigationBehaviorListener value)
		{
			this.ListenerListInternal.Add(value);
			this.IsListenerListDirty = true;
		}

		// Token: 0x0603314F RID: 209231 RVA: 0x00CCB2A0 File Offset: 0x00CC94A0
		public void RemoveListenerByIndex(int index)
		{
			this.ListenerListInternal.RemoveAt(index);
		}

		// Token: 0x1700879F RID: 34719
		// (get) Token: 0x06033150 RID: 209232 RVA: 0x00CCB2AE File Offset: 0x00CC94AE
		public List<TsUiNavigationBehaviorListener> ListenerList
		{
			get
			{
				if (this.IsListenerListDirty)
				{
					this.IsListenerListDirty = false;
					this.SortListenerListByFlattenHierarchyIndex();
				}
				return this.ListenerListInternal;
			}
		}

		// Token: 0x06033151 RID: 209233 RVA: 0x00CCB2CC File Offset: 0x00CC94CC
		private void SortListenerListByFlattenHierarchyIndex()
		{
			TArray<UUIItem> tarray = new TArray<UUIItem>();
			Dictionary<UUIItem, TsUiNavigationBehaviorListener> dictionary = new Dictionary<UUIItem, TsUiNavigationBehaviorListener>();
			List<TsUiNavigationBehaviorListener> list = new List<TsUiNavigationBehaviorListener>();
			int i = 0;
			int count = this.ListenerListInternal.Count;
			while (i < count)
			{
				TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = this.ListenerListInternal[i];
				if (!tsUiNavigationBehaviorListener.IsValid())
				{
					list.Add(tsUiNavigationBehaviorListener);
				}
				else
				{
					TWeakObjectPtr<UUIItem> rootUIComp = tsUiNavigationBehaviorListener.RootUIComp;
					tarray.Add(rootUIComp);
					dictionary[rootUIComp] = tsUiNavigationBehaviorListener;
				}
				i++;
			}
			TArray<UUIItem> sortedItemsWithFlattenHierarchyIndex = ULGUIBPLibrary.GetSortedItemsWithFlattenHierarchyIndex(tarray, true);
			this.ListenerListInternal.Clear();
			int j = 0;
			int count2 = sortedItemsWithFlattenHierarchyIndex.Count;
			while (j < count2)
			{
				TsUiNavigationBehaviorListener item;
				if (dictionary.TryGetValue(sortedItemsWithFlattenHierarchyIndex[j], out item))
				{
					this.ListenerListInternal.Add(item);
				}
				j++;
			}
			int k = 0;
			int count3 = list.Count;
			while (k < count3)
			{
				this.ListenerListInternal.Add(list[k]);
				k++;
			}
		}

		// Token: 0x06033152 RID: 209234 RVA: 0x00CCB3C8 File Offset: 0x00CC95C8
		private Dictionary<TsUiNavigationBehaviorListener, int> BuildHierarchyRankMap(IReadOnlyList<TsUiNavigationBehaviorListener> listenerList)
		{
			Dictionary<TsUiNavigationBehaviorListener, int> dictionary = new Dictionary<TsUiNavigationBehaviorListener, int>();
			int i = 0;
			int count = listenerList.Count;
			while (i < count)
			{
				dictionary[listenerList[i]] = i;
				i++;
			}
			return dictionary;
		}

		// Token: 0x170087A0 RID: 34720
		// (get) Token: 0x06033153 RID: 209235 RVA: 0x00CCB400 File Offset: 0x00CC9600
		public List<TsUiNavigationBehaviorListener> LoopScrollSortListenerList
		{
			get
			{
				List<TsUiNavigationBehaviorListener> listenerList = this.ListenerList;
				Dictionary<TsUiNavigationBehaviorListener, int> hierarchyRankMap = this.BuildHierarchyRankMap(listenerList);
				List<TsUiNavigationBehaviorListener> list = new List<TsUiNavigationBehaviorListener>(listenerList);
				list.Sort(delegate(TsUiNavigationBehaviorListener aListener, TsUiNavigationBehaviorListener bListener)
				{
					int num = 0;
					int num2 = 0;
					if (aListener.HasLoopScrollView() && bListener.HasLoopScrollView())
					{
						if (aListener.IsValid())
						{
							num = aListener.LoopScrollViewGridIndex;
						}
						if (bListener.IsValid())
						{
							num2 = bListener.LoopScrollViewGridIndex;
						}
						if (num != num2)
						{
							return num - num2;
						}
					}
					return hierarchyRankMap[aListener] - hierarchyRankMap[bListener];
				});
				return list;
			}
		}

		// Token: 0x170087A1 RID: 34721
		// (get) Token: 0x06033154 RID: 209236 RVA: 0x00CCB440 File Offset: 0x00CC9640
		public List<TsUiNavigationBehaviorListener> MultiTemplateScrollSortListenerList
		{
			get
			{
				List<TsUiNavigationBehaviorListener> listenerList = this.ListenerList;
				Dictionary<TsUiNavigationBehaviorListener, int> hierarchyRankMap = this.BuildHierarchyRankMap(listenerList);
				List<TsUiNavigationBehaviorListener> list = new List<TsUiNavigationBehaviorListener>(listenerList);
				list.Sort(delegate(TsUiNavigationBehaviorListener aListener, TsUiNavigationBehaviorListener bListener)
				{
					int num = 0;
					int num2 = 0;
					if (aListener.HasMultiTemplateScrollView() && bListener.HasMultiTemplateScrollView())
					{
						if (aListener.IsValid())
						{
							num = aListener.LoopScrollViewGridIndex;
						}
						if (bListener.IsValid())
						{
							num2 = bListener.LoopScrollViewGridIndex;
						}
						if (num != num2)
						{
							return num - num2;
						}
					}
					return hierarchyRankMap[aListener] - hierarchyRankMap[bListener];
				});
				return list;
			}
		}

		// Token: 0x170087A2 RID: 34722
		// (get) Token: 0x06033155 RID: 209237 RVA: 0x00CCB480 File Offset: 0x00CC9680
		public List<TsUiNavigationBehaviorListener> ActiveListenerList
		{
			get
			{
				List<TsUiNavigationBehaviorListener> list = new List<TsUiNavigationBehaviorListener>();
				int i = 0;
				int count = this.ListenerList.Count;
				while (i < count)
				{
					TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = this.ListenerList[i];
					if (tsUiNavigationBehaviorListener.IsListenerActive())
					{
						list.Add(tsUiNavigationBehaviorListener);
					}
					i++;
				}
				return list;
			}
		}

		// Token: 0x06033156 RID: 209238 RVA: 0x00CCB4C8 File Offset: 0x00CC96C8
		[NullableContext(2)]
		[return: Nullable(1)]
		public List<TsUiNavigationBehaviorListener> GetOppositeListenerListByListener(AActor srcScrollViewActor, AActor layoutViewActor)
		{
			if (this.AllowNavigationInSelfDynamic)
			{
				return new List<TsUiNavigationBehaviorListener>(this.ListenerList);
			}
			List<TsUiNavigationBehaviorListener> list = new List<TsUiNavigationBehaviorListener>();
			int i = 0;
			int count = this.ListenerList.Count;
			while (i < count)
			{
				TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = this.ListenerList[i];
				if ((srcScrollViewActor != null || tsUiNavigationBehaviorListener.ScrollViewActor != null || layoutViewActor != null || tsUiNavigationBehaviorListener.LayoutActor != null) && srcScrollViewActor == tsUiNavigationBehaviorListener.ScrollViewActor && layoutViewActor == tsUiNavigationBehaviorListener.LayoutActor)
				{
					list.Add(tsUiNavigationBehaviorListener);
				}
				i++;
			}
			return list;
		}

		// Token: 0x06033157 RID: 209239 RVA: 0x00CCB544 File Offset: 0x00CC9744
		public NavigationGroup(SNavigationGroup config)
		{
			this.Config = config;
			if (!string.IsNullOrEmpty(this.Config.InsideGroupName))
			{
				this.InsideGroupNameSetInternal.Add(this.Config.InsideGroupName);
			}
			int i = 0;
			int num = this.Config.ExtraInsideGroupNameList.Num();
			while (i < num)
			{
				string text = this.Config.ExtraInsideGroupNameList.Get(i);
				if (!string.IsNullOrEmpty(text))
				{
					this.InsideGroupNameSetInternal.Add(text);
				}
				i++;
			}
		}

		// Token: 0x170087A3 RID: 34723
		// (get) Token: 0x06033158 RID: 209240 RVA: 0x00CCB5E1 File Offset: 0x00CC97E1
		public bool AllowNavigationInSelfDynamic
		{
			get
			{
				return this.Config.AllowNavigationInSelfDynamic;
			}
		}

		// Token: 0x170087A4 RID: 34724
		// (get) Token: 0x06033159 RID: 209241 RVA: 0x00CCB5EE File Offset: 0x00CC97EE
		// (set) Token: 0x0603315A RID: 209242 RVA: 0x00CCB5F6 File Offset: 0x00CC97F6
		[Nullable(2)]
		public TsUiNavigationBehaviorListener DefaultListener
		{
			[NullableContext(2)]
			get
			{
				return this.DefaultListenerInternal;
			}
			[NullableContext(2)]
			set
			{
				this.DefaultListenerInternal = value;
			}
		}

		// Token: 0x170087A5 RID: 34725
		// (get) Token: 0x0603315B RID: 209243 RVA: 0x00CCB5FF File Offset: 0x00CC97FF
		public string GroupName
		{
			get
			{
				return this.Config.GroupName;
			}
		}

		// Token: 0x170087A6 RID: 34726
		// (get) Token: 0x0603315C RID: 209244 RVA: 0x00CCB60C File Offset: 0x00CC980C
		public TMap<string, string> GroupNameMap
		{
			get
			{
				return this.Config.GroupNameMap;
			}
		}

		// Token: 0x170087A7 RID: 34727
		// (get) Token: 0x0603315D RID: 209245 RVA: 0x00CCB619 File Offset: 0x00CC9819
		public int GroupType
		{
			get
			{
				return this.Config.GroupType;
			}
		}

		// Token: 0x170087A8 RID: 34728
		// (get) Token: 0x0603315E RID: 209246 RVA: 0x00CCB626 File Offset: 0x00CC9826
		public UINavigationPriorityMode HorizontalPriorityMode
		{
			get
			{
				return this.Config.HorizontalPriorityMode;
			}
		}

		// Token: 0x170087A9 RID: 34729
		// (get) Token: 0x0603315F RID: 209247 RVA: 0x00CCB633 File Offset: 0x00CC9833
		public UINavigationWrapMode HorizontalWrapMode
		{
			get
			{
				return this.Config.HorizontalWrapMode;
			}
		}

		// Token: 0x170087AA RID: 34730
		// (get) Token: 0x06033160 RID: 209248 RVA: 0x00CCB640 File Offset: 0x00CC9840
		public string InsideGroupName
		{
			get
			{
				return this.Config.InsideGroupName;
			}
		}

		// Token: 0x170087AB RID: 34731
		// (get) Token: 0x06033161 RID: 209249 RVA: 0x00CCB64D File Offset: 0x00CC984D
		public HashSet<string> InsideGroupNameSet
		{
			get
			{
				return this.InsideGroupNameSetInternal;
			}
		}

		// Token: 0x170087AC RID: 34732
		// (get) Token: 0x06033162 RID: 209250 RVA: 0x00CCB655 File Offset: 0x00CC9855
		// (set) Token: 0x06033163 RID: 209251 RVA: 0x00CCB65D File Offset: 0x00CC985D
		[Nullable(2)]
		public TsUiNavigationBehaviorListener LastSelectListener
		{
			[NullableContext(2)]
			get
			{
				return this.LastListenerInternal;
			}
			[NullableContext(2)]
			set
			{
				this.LastListenerInternal = value;
			}
		}

		// Token: 0x170087AD RID: 34733
		// (get) Token: 0x06033164 RID: 209252 RVA: 0x00CCB666 File Offset: 0x00CC9866
		public string NextGroupName
		{
			get
			{
				return this.Config.NextGroupName;
			}
		}

		// Token: 0x170087AE RID: 34734
		// (get) Token: 0x06033165 RID: 209253 RVA: 0x00CCB673 File Offset: 0x00CC9873
		// (set) Token: 0x06033166 RID: 209254 RVA: 0x00CCB680 File Offset: 0x00CC9880
		public string PrevGroupName
		{
			get
			{
				return this.Config.PrevGroupName;
			}
			set
			{
				this.Config.PrevGroupName = value;
			}
		}

		// Token: 0x170087AF RID: 34735
		// (get) Token: 0x06033167 RID: 209255 RVA: 0x00CCB68E File Offset: 0x00CC988E
		public bool RefreshNavigation
		{
			get
			{
				return this.Config.RefreshNavigation;
			}
		}

		// Token: 0x170087B0 RID: 34736
		// (get) Token: 0x06033168 RID: 209256 RVA: 0x00CCB69B File Offset: 0x00CC989B
		public bool SelectableMemory
		{
			get
			{
				return this.Config.SelectableMemory;
			}
		}

		// Token: 0x170087B1 RID: 34737
		// (get) Token: 0x06033169 RID: 209257 RVA: 0x00CCB6A8 File Offset: 0x00CC98A8
		public bool SuitableListenerByNoDynamic
		{
			get
			{
				return this.Config.SuitableListenerByNoDynamic;
			}
		}

		// Token: 0x170087B2 RID: 34738
		// (get) Token: 0x0603316A RID: 209258 RVA: 0x00CCB6B5 File Offset: 0x00CC98B5
		public UINavigationPriorityMode VerticalPriorityMode
		{
			get
			{
				return this.Config.VerticalPriorityMode;
			}
		}

		// Token: 0x170087B3 RID: 34739
		// (get) Token: 0x0603316B RID: 209259 RVA: 0x00CCB6C2 File Offset: 0x00CC98C2
		public UINavigationWrapMode VerticalWrapMode
		{
			get
			{
				return this.Config.VerticalWrapMode;
			}
		}

		// Token: 0x170087B4 RID: 34740
		// (get) Token: 0x0603316C RID: 209260 RVA: 0x00CCB6CF File Offset: 0x00CC98CF
		public bool SlideToLeftOrTop
		{
			get
			{
				return this.Config.SlideToLeftOrTop;
			}
		}

		// Token: 0x170087B5 RID: 34741
		// (get) Token: 0x0603316D RID: 209261 RVA: 0x00CCB6DC File Offset: 0x00CC98DC
		public bool SlideToRightOrDown
		{
			get
			{
				return this.Config.SlideToRightOrDown;
			}
		}

		// Token: 0x170087B6 RID: 34742
		// (get) Token: 0x0603316E RID: 209262 RVA: 0x00CCB6E9 File Offset: 0x00CC98E9
		public bool WaitScrollAnimation
		{
			get
			{
				return this.Config.WaitScrollAnimation;
			}
		}

		// Token: 0x0401DB56 RID: 121686
		private readonly SNavigationGroup Config;

		// Token: 0x0401DB57 RID: 121687
		private readonly HashSet<string> InsideGroupNameSetInternal = new HashSet<string>();

		// Token: 0x0401DB58 RID: 121688
		[Nullable(2)]
		private TsUiNavigationBehaviorListener DefaultListenerInternal;

		// Token: 0x0401DB59 RID: 121689
		[Nullable(2)]
		private TsUiNavigationBehaviorListener LastListenerInternal;

		// Token: 0x0401DB5A RID: 121690
		private bool IsListenerListDirty;

		// Token: 0x0401DB5B RID: 121691
		private readonly List<TsUiNavigationBehaviorListener> ListenerListInternal = new List<TsUiNavigationBehaviorListener>();
	}
}
