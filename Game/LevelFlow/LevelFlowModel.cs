using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelFlow.Action;
using CSharpScript.Game.LevelFlow.Section;

namespace CSharpScript.Game.LevelFlow
{
	// Token: 0x02006F76 RID: 28534
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LevelFlowModel : ModelBase<LevelFlowModel>
	{
		// Token: 0x060450D8 RID: 282840 RVA: 0x011FBC65 File Offset: 0x011F9E65
		public void InitTaskTreeInfo(long treeIncId, int treeNodeId)
		{
			this.TreeIncIdInternal = treeIncId;
			this.TreeNodeIdInternal = treeNodeId;
		}

		// Token: 0x060450D9 RID: 282841 RVA: 0x011FBC75 File Offset: 0x011F9E75
		public void InitTiTanLevelFlowInfo()
		{
			this.SectionData = new LevelFlowTiTanData();
			this.SectionData.Init();
		}

		// Token: 0x060450DA RID: 282842 RVA: 0x011FBC90 File Offset: 0x011F9E90
		public void StartLevelFlow(int index)
		{
			if (this.SectionData.GetCapacity() <= 0)
			{
				return;
			}
			this.IsEndInternal = false;
			this.CurrentSectionIndex = index;
			LevelFlowSection section = this.SectionData.GetSection(this.CurrentSectionIndex);
			if (section == null)
			{
				return;
			}
			this.CurrentSection = section;
			this.ExecuteSection(section);
		}

		// Token: 0x060450DB RID: 282843 RVA: 0x011FBCE0 File Offset: 0x011F9EE0
		public void OnTick(float delta)
		{
			if (this.CurrentSection == null)
			{
				return;
			}
			this.CurrentSection.Tick(delta);
			foreach (LevelFlowActionBase levelFlowActionBase in this.DynamicActionSet)
			{
				levelFlowActionBase.Tick(delta);
			}
		}

		// Token: 0x060450DC RID: 282844 RVA: 0x011FBD48 File Offset: 0x011F9F48
		private void ExecuteSection(LevelFlowSection section)
		{
			section.BindCompleteCallBack(new Action<LevelFlowSection, bool>(this.OnSectionComplete));
			section.Enter();
		}

		// Token: 0x060450DD RID: 282845 RVA: 0x011FBD64 File Offset: 0x011F9F64
		public void ResetLevelFlow(bool isEnd = false)
		{
			this.IsEndInternal = isEnd;
			if (this.CurrentSection != null)
			{
				this.CurrentSection.BindResetCompleteCallBack(new Action<LevelFlowSection, bool>(this.OnSectionResetComplete));
				this.CurrentSection.Reset();
			}
			foreach (LevelFlowActionBase levelFlowActionBase in this.DynamicActionSet)
			{
				levelFlowActionBase.Reset();
			}
			this.DynamicActionSet.Clear();
		}

		// Token: 0x060450DE RID: 282846 RVA: 0x011FBDF0 File Offset: 0x011F9FF0
		public void RollBackLevelFlow(Action<bool> rollbackCompleteCallBack)
		{
			if (this.CurrentSection == null)
			{
				rollbackCompleteCallBack(true);
				return;
			}
			this.RollbackCompleteCallBack = rollbackCompleteCallBack;
			this.ResetLevelFlow(true);
		}

		// Token: 0x060450DF RID: 282847 RVA: 0x011FBE10 File Offset: 0x011FA010
		public void PushDynamicAction(LevelFlowActionBase action)
		{
			if (this.IsEnd)
			{
				return;
			}
			if (this.CurrentSection == null)
			{
				return;
			}
			this.DynamicActionSet.Add(action);
			action.BindCompleteCallBack(new Action<LevelFlowActionBase, bool>(this.OnDynamicActionComplete));
			action.Execute();
		}

		// Token: 0x060450E0 RID: 282848 RVA: 0x011FBE4C File Offset: 0x011FA04C
		private void OnSectionComplete(LevelFlowSection section, bool isSuccess)
		{
			if (!isSuccess)
			{
				if (this.IsDebug)
				{
					return;
				}
				this.ResetLevelFlow(false);
				return;
			}
			else
			{
				if (section.SectionId != this.CurrentSection.SectionId)
				{
					Singleton<Log>.Instance.Error(ELogModule.LevelFlow, ELogAuthor.BB, "section回调异常", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				this.CurrentSection.Exit();
				this.CurrentSectionIndex++;
				if (this.CurrentSectionIndex >= this.SectionData.GetCapacity())
				{
					this.End();
					Singleton<EventSystem>.Instance.Emit(EEventName.OnLevelFlowFinished);
					return;
				}
				LevelFlowSection section2 = this.SectionData.GetSection(this.CurrentSectionIndex);
				if (section2 == null)
				{
					return;
				}
				this.CurrentSection = section2;
				this.ExecuteSection(section2);
				return;
			}
		}

		// Token: 0x060450E1 RID: 282849 RVA: 0x011FBF07 File Offset: 0x011FA107
		private void End()
		{
			this.CurrentSection = null;
			LevelFlowResourceManager.Release();
		}

		// Token: 0x060450E2 RID: 282850 RVA: 0x011FBF18 File Offset: 0x011FA118
		private void OnSectionResetComplete(LevelFlowSection section, bool isSuccess)
		{
			if (this.IsEndInternal)
			{
				this.End();
				Action<bool> rollbackCompleteCallBack = this.RollbackCompleteCallBack;
				if (rollbackCompleteCallBack != null)
				{
					rollbackCompleteCallBack(isSuccess);
				}
				this.RollbackCompleteCallBack = null;
				return;
			}
			if (!isSuccess)
			{
				Singleton<Log>.Instance.Error(ELogModule.LevelFlow, ELogAuthor.BB, "回退都失败了，怎么能成功呢", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (section.SectionId != this.CurrentSection.SectionId)
			{
				Singleton<Log>.Instance.Error(ELogModule.LevelFlow, ELogAuthor.BB, "section回调异常", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.CurrentSection.Enter();
		}

		// Token: 0x060450E3 RID: 282851 RVA: 0x011FBFAE File Offset: 0x011FA1AE
		private void OnDynamicActionComplete(LevelFlowActionBase action, bool isSuccess)
		{
			if (!isSuccess)
			{
				return;
			}
			this.DynamicActionSet.Remove(action);
		}

		// Token: 0x1700A4A5 RID: 42149
		// (get) Token: 0x060450E4 RID: 282852 RVA: 0x011FBFC1 File Offset: 0x011FA1C1
		public long TreeIncId
		{
			get
			{
				return this.TreeIncIdInternal;
			}
		}

		// Token: 0x1700A4A6 RID: 42150
		// (get) Token: 0x060450E5 RID: 282853 RVA: 0x011FBFC9 File Offset: 0x011FA1C9
		public int TreeNodeId
		{
			get
			{
				return this.TreeNodeIdInternal;
			}
		}

		// Token: 0x1700A4A7 RID: 42151
		// (get) Token: 0x060450E6 RID: 282854 RVA: 0x011FBFD1 File Offset: 0x011FA1D1
		public bool IsEnd
		{
			get
			{
				return this.IsEndInternal;
			}
		}

		// Token: 0x0402686B RID: 157803
		public bool IsDebug;

		// Token: 0x0402686C RID: 157804
		public bool IsIgnoreForceMove;

		// Token: 0x0402686D RID: 157805
		private long TreeIncIdInternal;

		// Token: 0x0402686E RID: 157806
		private int TreeNodeIdInternal;

		// Token: 0x0402686F RID: 157807
		[Nullable(2)]
		private LevelFlowData SectionData;

		// Token: 0x04026870 RID: 157808
		private int CurrentSectionIndex;

		// Token: 0x04026871 RID: 157809
		[Nullable(2)]
		private LevelFlowSection CurrentSection;

		// Token: 0x04026872 RID: 157810
		private bool IsEndInternal;

		// Token: 0x04026873 RID: 157811
		private readonly HashSet<LevelFlowActionBase> DynamicActionSet = new HashSet<LevelFlowActionBase>();

		// Token: 0x04026874 RID: 157812
		[Nullable(2)]
		private Action<bool> RollbackCompleteCallBack;
	}
}
