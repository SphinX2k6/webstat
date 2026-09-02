using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi.Views;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052FF RID: 21247
	[NullableContext(1)]
	[Nullable(0)]
	public class QuickHackMarksView : BattleChildView
	{
		// Token: 0x060363C2 RID: 222146 RVA: 0x00DAABA8 File Offset: 0x00DA8DA8
		[NullableContext(2)]
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			QuickHackMarkManager markManager = ModelBase<QuickHackModel>.Instance.MarkManager;
			if (markManager != null)
			{
				markManager.UpdateMarks();
				foreach (QuickHackMarkInstance mark in markManager.GetMarks())
				{
					this.PushMark(mark);
				}
			}
			Singleton<EventSystem>.Instance.Add<QuickHackMarkInstance>(EEventName.OnQuickHackStartMark, new Action<QuickHackMarkInstance>(this.OnQuickHackStartMark));
		}

		// Token: 0x060363C3 RID: 222147 RVA: 0x00DAAC2C File Offset: 0x00DA8E2C
		public override void Reset()
		{
			base.Reset();
			Dictionary<EntityHandle, QuickHackMarksItem> marksItemMap = this.MarksItemMap;
			if (marksItemMap != null)
			{
				marksItemMap.Clear();
			}
			this.MarksItemMap = null;
			Queue<QuickHackMarkInstance> waitMarkQueue = this.WaitMarkQueue;
			if (waitMarkQueue != null)
			{
				waitMarkQueue.Clear();
			}
			this.WaitMarkQueue = null;
			this.TempVector = null;
			this.TempScreenPosition = null;
			Singleton<EventSystem>.Instance.Remove<QuickHackMarkInstance>(EEventName.OnQuickHackStartMark, new Action<QuickHackMarkInstance>(this.OnQuickHackStartMark));
		}

		// Token: 0x060363C4 RID: 222148 RVA: 0x00DAAC99 File Offset: 0x00DA8E99
		public void OnShowBattleChildViewPanel()
		{
			QuickHackMarkManager markManager = ModelBase<QuickHackModel>.Instance.MarkManager;
			if (markManager == null)
			{
				return;
			}
			markManager.UpdateMarks();
		}

		// Token: 0x060363C5 RID: 222149 RVA: 0x00DAACAF File Offset: 0x00DA8EAF
		public void Update()
		{
			this.ConsumeWaitMarks();
			this.UpdateAllMarksItem();
		}

		// Token: 0x060363C6 RID: 222150 RVA: 0x00DAACC0 File Offset: 0x00DA8EC0
		private void ConsumeWaitMarks()
		{
			if (this.WaitMarkQueue == null || this.WaitMarkQueue.Size <= 0)
			{
				return;
			}
			for (int i = 0; i < 3; i++)
			{
				QuickHackMarkInstance quickHackMarkInstance = this.WaitMarkQueue.Pop();
				if (quickHackMarkInstance != null)
				{
					this.StartMarkAsync(quickHackMarkInstance).Forget();
				}
				if (this.WaitMarkQueue.Size <= 0)
				{
					break;
				}
			}
		}

		// Token: 0x060363C7 RID: 222151 RVA: 0x00DAAD1C File Offset: 0x00DA8F1C
		private void UpdateAllMarksItem()
		{
			if (this.MarksItemMap == null || this.MarksItemMap.Count <= 0)
			{
				return;
			}
			QuickHackMarkManager markManager = ModelBase<QuickHackModel>.Instance.MarkManager;
			if (markManager != null)
			{
				markManager.UpdateMarks();
			}
			if (this.TempVector == null)
			{
				this.TempVector = Vector.Create();
			}
			if (this.TempScreenPosition == null)
			{
				this.TempScreenPosition = Vector2D.Create();
			}
			List<EntityHandle> list = new List<EntityHandle>();
			foreach (KeyValuePair<EntityHandle, QuickHackMarksItem> keyValuePair in this.MarksItemMap)
			{
				EntityHandle entityHandle;
				QuickHackMarksItem quickHackMarksItem;
				keyValuePair.Deconstruct(out entityHandle, out quickHackMarksItem);
				EntityHandle item = entityHandle;
				QuickHackMarksItem quickHackMarksItem2 = quickHackMarksItem;
				if (!quickHackMarksItem2.GetWorldLocation(this.TempVector))
				{
					quickHackMarksItem2.Destroy(null);
					list.Add(item);
				}
				else if (!HudUnitUtils.PositionUtil.ProjectWorldToScreen(this.TempVector.ToUeVector(false), this.TempScreenPosition))
				{
					quickHackMarksItem2.SetActive(false);
				}
				else
				{
					quickHackMarksItem2.SetActive(true);
					quickHackMarksItem2.GetRootItem().SetAnchorOffset(this.TempScreenPosition.ToUeVector2D(false));
				}
			}
			foreach (EntityHandle key in list)
			{
				this.MarksItemMap.Remove(key);
			}
		}

		// Token: 0x060363C8 RID: 222152 RVA: 0x00DAAE80 File Offset: 0x00DA9080
		private void OnQuickHackStartMark(QuickHackMarkInstance mark)
		{
			this.PushMark(mark);
		}

		// Token: 0x060363C9 RID: 222153 RVA: 0x00DAAE89 File Offset: 0x00DA9089
		private void PushMark(QuickHackMarkInstance mark)
		{
			if (this.WaitMarkQueue == null)
			{
				this.WaitMarkQueue = new Queue<QuickHackMarkInstance>(4);
			}
			this.WaitMarkQueue.Push(mark);
		}

		// Token: 0x060363CA RID: 222154 RVA: 0x00DAAEAC File Offset: 0x00DA90AC
		private UniTask StartMarkAsync(QuickHackMarkInstance mark)
		{
			QuickHackMarksView.<StartMarkAsync>d__13 <StartMarkAsync>d__;
			<StartMarkAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartMarkAsync>d__.<>4__this = this;
			<StartMarkAsync>d__.mark = mark;
			<StartMarkAsync>d__.<>1__state = -1;
			<StartMarkAsync>d__.<>t__builder.Start<QuickHackMarksView.<StartMarkAsync>d__13>(ref <StartMarkAsync>d__);
			return <StartMarkAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060363CB RID: 222155 RVA: 0x00DAAEF8 File Offset: 0x00DA90F8
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<QuickHackMarksItem> GetOrCreateMarksItem(EntityHandle owner)
		{
			QuickHackMarksView.<GetOrCreateMarksItem>d__14 <GetOrCreateMarksItem>d__;
			<GetOrCreateMarksItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<QuickHackMarksItem>.Create();
			<GetOrCreateMarksItem>d__.<>4__this = this;
			<GetOrCreateMarksItem>d__.owner = owner;
			<GetOrCreateMarksItem>d__.<>1__state = -1;
			<GetOrCreateMarksItem>d__.<>t__builder.Start<QuickHackMarksView.<GetOrCreateMarksItem>d__14>(ref <GetOrCreateMarksItem>d__);
			return <GetOrCreateMarksItem>d__.<>t__builder.Task;
		}

		// Token: 0x060363CC RID: 222156 RVA: 0x00DAAF44 File Offset: 0x00DA9144
		private void OnMarksFinish(EntityHandle owner)
		{
			if (this.MarksItemMap == null)
			{
				return;
			}
			QuickHackMarksItem quickHackMarksItem;
			if (this.MarksItemMap.TryGetValue(owner, out quickHackMarksItem))
			{
				this.MarksItemMap.Remove(owner);
				quickHackMarksItem.Destroy(null);
			}
		}

		// Token: 0x0401F2F3 RID: 127731
		private const int SHOW_MAX_SIZE_PER_UPDATE = 3;

		// Token: 0x0401F2F4 RID: 127732
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Queue<QuickHackMarkInstance> WaitMarkQueue;

		// Token: 0x0401F2F5 RID: 127733
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Dictionary<EntityHandle, QuickHackMarksItem> MarksItemMap;

		// Token: 0x0401F2F6 RID: 127734
		[Nullable(2)]
		private Vector TempVector;

		// Token: 0x0401F2F7 RID: 127735
		[Nullable(2)]
		private Vector2D TempScreenPosition;
	}
}
