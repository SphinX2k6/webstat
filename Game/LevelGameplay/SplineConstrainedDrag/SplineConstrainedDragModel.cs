using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Define;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Interface;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag
{
	// Token: 0x02006ADD RID: 27357
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class SplineConstrainedDragModel : ModelBase<SplineConstrainedDragModel>
	{
		// Token: 0x06043A32 RID: 277042 RVA: 0x011732B4 File Offset: 0x011714B4
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x06043A33 RID: 277043 RVA: 0x011732B8 File Offset: 0x011714B8
		protected override bool OnClear()
		{
			foreach (KeyValuePair<string, IKuroSplineConstrainedDrag> keyValuePair in this.KuroSplineConstrainedDrags)
			{
				string text;
				IKuroSplineConstrainedDrag kuroSplineConstrainedDrag;
				keyValuePair.Deconstruct(out text, out kuroSplineConstrainedDrag);
				kuroSplineConstrainedDrag.Clear();
			}
			this.KuroSplineConstrainedDrags.Clear();
			this.ActiveDrag = null;
			this.ActiveDragSource = EDragSource.None;
			this.SelectionMatDataCache.Clear();
			this.SelectionMatHandle = null;
			this.GamepadAxisX = 0f;
			this.GamepadAxisY = 0f;
			this.GamepadDragPaused = false;
			this.TitleTid = null;
			this.DescTid = null;
			this.HintTid = null;
			this.LastPointerPosition.Reset();
			this.DragActorPlayActive = false;
			if (this.ForbidEvalDisableRefCount > 0)
			{
				this.ForbidEvalDisableRefCount = 0;
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Animation.ForbiddenEvaluateTwice 1", null);
			}
			this.DisableExit = false;
			return true;
		}

		// Token: 0x06043A34 RID: 277044 RVA: 0x011733B4 File Offset: 0x011715B4
		public bool GetDragActorPlayActive()
		{
			return this.DragActorPlayActive;
		}

		// Token: 0x06043A35 RID: 277045 RVA: 0x011733BC File Offset: 0x011715BC
		public void SetDragActorPlayActive(bool active)
		{
			if (this.DragActorPlayActive == active)
			{
				return;
			}
			this.DragActorPlayActive = active;
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.DragActorPlayActivationChanged, active);
		}

		// Token: 0x06043A36 RID: 277046 RVA: 0x011733E0 File Offset: 0x011715E0
		public void BroadcastDragActorPlayConditionRecheck()
		{
			if (!this.DragActorPlayActive)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.DragActorPlayConditionRecheck);
		}

		// Token: 0x06043A37 RID: 277047 RVA: 0x011733FB File Offset: 0x011715FB
		public void RegisterKuroSplineConstrainedDrag(string key, IKuroSplineConstrainedDrag kuroSplineConstrainedDrag)
		{
			this.KuroSplineConstrainedDrags[key] = kuroSplineConstrainedDrag;
		}

		// Token: 0x06043A38 RID: 277048 RVA: 0x0117340C File Offset: 0x0117160C
		public void UnregisterKuroSplineConstrainedDrag(string key)
		{
			IKuroSplineConstrainedDrag valueOrDefault = this.KuroSplineConstrainedDrags.GetValueOrDefault(key);
			if (valueOrDefault == null)
			{
				return;
			}
			if (this.ActiveDrag == valueOrDefault)
			{
				this.ActiveDrag = null;
				this.ActiveDragSource = EDragSource.None;
			}
			valueOrDefault.Clear();
			this.KuroSplineConstrainedDrags.Remove(key);
		}

		// Token: 0x06043A39 RID: 277049 RVA: 0x01173454 File Offset: 0x01171654
		[return: Nullable(2)]
		public IKuroSplineConstrainedDrag GetKuroSplineConstrainedDrag(string key)
		{
			return this.KuroSplineConstrainedDrags.GetValueOrDefault(key);
		}

		// Token: 0x06043A3A RID: 277050 RVA: 0x01173462 File Offset: 0x01171662
		public IReadOnlyDictionary<string, IKuroSplineConstrainedDrag> GetAllKuroSplineConstrainedDrags()
		{
			return this.KuroSplineConstrainedDrags;
		}

		// Token: 0x06043A3B RID: 277051 RVA: 0x0117346A File Offset: 0x0117166A
		[NullableContext(2)]
		public IKuroSplineConstrainedDrag GetActiveSplineConstrainedDrag()
		{
			return this.ActiveDrag;
		}

		// Token: 0x06043A3C RID: 277052 RVA: 0x01173472 File Offset: 0x01171672
		public EDragSource GetActiveDragSource()
		{
			return this.ActiveDragSource;
		}

		// Token: 0x06043A3D RID: 277053 RVA: 0x0117347A File Offset: 0x0117167A
		[NullableContext(2)]
		public string GetActiveDragActorKey()
		{
			IKuroSplineConstrainedDrag activeDrag = this.ActiveDrag;
			if (activeDrag == null)
			{
				return null;
			}
			return activeDrag.GetActorKey();
		}

		// Token: 0x06043A3E RID: 277054 RVA: 0x0117348D File Offset: 0x0117168D
		[NullableContext(2)]
		public void SetActiveSplineConstrainedDrag(IKuroSplineConstrainedDrag drag, EDragSource source)
		{
			this.ActiveDrag = drag;
			this.ActiveDragSource = ((drag == null) ? EDragSource.None : source);
		}

		// Token: 0x06043A3F RID: 277055 RVA: 0x011734A3 File Offset: 0x011716A3
		[return: Nullable(2)]
		public ISelectionMatCacheEntry GetSelectionMatCacheEntry(string daPath)
		{
			return this.SelectionMatDataCache.GetValueOrDefault(daPath);
		}

		// Token: 0x06043A40 RID: 277056 RVA: 0x011734B4 File Offset: 0x011716B4
		public bool AddSelectionMatRef(string daPath, int holderId)
		{
			ISelectionMatCacheEntry valueOrDefault = this.SelectionMatDataCache.GetValueOrDefault(daPath);
			if (valueOrDefault != null)
			{
				valueOrDefault.RefHolders.Add(holderId);
				return false;
			}
			ISelectionMatCacheEntry value = new SelectionMatCacheEntry
			{
				Asset = null,
				RefHolders = new HashSet<int>
				{
					holderId
				}
			};
			this.SelectionMatDataCache[daPath] = value;
			return true;
		}

		// Token: 0x06043A41 RID: 277057 RVA: 0x01173510 File Offset: 0x01171710
		public void SetSelectionMatAsset(string daPath, [Nullable(2)] ItemMaterialControllerActorData asset)
		{
			ISelectionMatCacheEntry valueOrDefault = this.SelectionMatDataCache.GetValueOrDefault(daPath);
			if (valueOrDefault == null)
			{
				return;
			}
			valueOrDefault.Asset = asset;
		}

		// Token: 0x06043A42 RID: 277058 RVA: 0x01173538 File Offset: 0x01171738
		public void RemoveSelectionMatRefByHolder(int holderId)
		{
			foreach (KeyValuePair<string, ISelectionMatCacheEntry> keyValuePair in this.SelectionMatDataCache)
			{
				string text;
				ISelectionMatCacheEntry selectionMatCacheEntry;
				keyValuePair.Deconstruct(out text, out selectionMatCacheEntry);
				string key = text;
				ISelectionMatCacheEntry selectionMatCacheEntry2 = selectionMatCacheEntry;
				if (selectionMatCacheEntry2.RefHolders.Remove(holderId) && selectionMatCacheEntry2.RefHolders.Count == 0)
				{
					this.SelectionMatDataCache.Remove(key);
				}
			}
		}

		// Token: 0x06043A43 RID: 277059 RVA: 0x011735C0 File Offset: 0x011717C0
		public int? GetSelectionMatHandle()
		{
			return this.SelectionMatHandle;
		}

		// Token: 0x06043A44 RID: 277060 RVA: 0x011735C8 File Offset: 0x011717C8
		public void SetSelectionMatHandle(int? handle)
		{
			this.SelectionMatHandle = handle;
		}

		// Token: 0x06043A45 RID: 277061 RVA: 0x011735D1 File Offset: 0x011717D1
		[NullableContext(2)]
		public string GetTitleTid()
		{
			return this.TitleTid;
		}

		// Token: 0x06043A46 RID: 277062 RVA: 0x011735D9 File Offset: 0x011717D9
		[NullableContext(2)]
		public string GetDescTid()
		{
			return this.DescTid;
		}

		// Token: 0x06043A47 RID: 277063 RVA: 0x011735E1 File Offset: 0x011717E1
		[NullableContext(2)]
		public void SetTitleTid(string tid)
		{
			this.TitleTid = tid;
		}

		// Token: 0x06043A48 RID: 277064 RVA: 0x011735EA File Offset: 0x011717EA
		[NullableContext(2)]
		public void SetDescTid(string tid)
		{
			this.DescTid = tid;
		}

		// Token: 0x06043A49 RID: 277065 RVA: 0x011735F3 File Offset: 0x011717F3
		[NullableContext(2)]
		public string GetHintTid()
		{
			return this.HintTid;
		}

		// Token: 0x06043A4A RID: 277066 RVA: 0x011735FB File Offset: 0x011717FB
		[NullableContext(2)]
		public void SetHintTid(string tid)
		{
			this.HintTid = tid;
		}

		// Token: 0x06043A4B RID: 277067 RVA: 0x01173604 File Offset: 0x01171804
		public float GetGamepadAxisX()
		{
			return this.GamepadAxisX;
		}

		// Token: 0x06043A4C RID: 277068 RVA: 0x0117360C File Offset: 0x0117180C
		public float GetGamepadAxisY()
		{
			return this.GamepadAxisY;
		}

		// Token: 0x06043A4D RID: 277069 RVA: 0x01173614 File Offset: 0x01171814
		public void SetGamepadAxisX(float value)
		{
			this.GamepadAxisX = value;
		}

		// Token: 0x06043A4E RID: 277070 RVA: 0x0117361D File Offset: 0x0117181D
		public void SetGamepadAxisY(float value)
		{
			this.GamepadAxisY = value;
		}

		// Token: 0x06043A4F RID: 277071 RVA: 0x01173626 File Offset: 0x01171826
		public bool GetGamepadDragPaused()
		{
			return this.GamepadDragPaused;
		}

		// Token: 0x06043A50 RID: 277072 RVA: 0x0117362E File Offset: 0x0117182E
		public void SetGamepadDragPaused(bool paused)
		{
			this.GamepadDragPaused = paused;
		}

		// Token: 0x06043A51 RID: 277073 RVA: 0x01173637 File Offset: 0x01171837
		public void AcquireForbidEvalDisable()
		{
			this.ForbidEvalDisableRefCount++;
			if (this.ForbidEvalDisableRefCount == 1)
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Animation.ForbiddenEvaluateTwice 0", null);
			}
		}

		// Token: 0x06043A52 RID: 277074 RVA: 0x01173660 File Offset: 0x01171860
		public void ReleaseForbidEvalDisable()
		{
			if (this.ForbidEvalDisableRefCount <= 0)
			{
				return;
			}
			this.ForbidEvalDisableRefCount--;
			if (this.ForbidEvalDisableRefCount == 0)
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Animation.ForbiddenEvaluateTwice 1", null);
			}
		}

		// Token: 0x06043A53 RID: 277075 RVA: 0x01173692 File Offset: 0x01171892
		public void SetDisableExit(bool disable)
		{
			this.DisableExit = disable;
		}

		// Token: 0x06043A54 RID: 277076 RVA: 0x0117369B File Offset: 0x0117189B
		public bool GetDisableExit()
		{
			return this.DisableExit;
		}

		// Token: 0x04025C96 RID: 154774
		private bool DragActorPlayActive;

		// Token: 0x04025C97 RID: 154775
		private readonly Dictionary<string, IKuroSplineConstrainedDrag> KuroSplineConstrainedDrags = new Dictionary<string, IKuroSplineConstrainedDrag>();

		// Token: 0x04025C98 RID: 154776
		[Nullable(2)]
		private IKuroSplineConstrainedDrag ActiveDrag;

		// Token: 0x04025C99 RID: 154777
		private EDragSource ActiveDragSource;

		// Token: 0x04025C9A RID: 154778
		private readonly Dictionary<string, ISelectionMatCacheEntry> SelectionMatDataCache = new Dictionary<string, ISelectionMatCacheEntry>();

		// Token: 0x04025C9B RID: 154779
		private int? SelectionMatHandle;

		// Token: 0x04025C9C RID: 154780
		private float GamepadAxisX;

		// Token: 0x04025C9D RID: 154781
		private float GamepadAxisY;

		// Token: 0x04025C9E RID: 154782
		private bool GamepadDragPaused;

		// Token: 0x04025C9F RID: 154783
		[Nullable(2)]
		private string TitleTid;

		// Token: 0x04025CA0 RID: 154784
		[Nullable(2)]
		private string DescTid;

		// Token: 0x04025CA1 RID: 154785
		[Nullable(2)]
		private string HintTid;

		// Token: 0x04025CA2 RID: 154786
		private int ForbidEvalDisableRefCount;

		// Token: 0x04025CA3 RID: 154787
		public readonly UKuroHitResult KuroHitResult = new UKuroHitResult();

		// Token: 0x04025CA4 RID: 154788
		public readonly Vector TempPointerPosition = Vector.Create();

		// Token: 0x04025CA5 RID: 154789
		public readonly Vector TempBeginScreenPosition = Vector.Create();

		// Token: 0x04025CA6 RID: 154790
		public readonly Vector LastPointerPosition = Vector.Create();

		// Token: 0x04025CA7 RID: 154791
		public readonly Vector TempPointerScreenDelta = Vector.Create();

		// Token: 0x04025CA8 RID: 154792
		public readonly Vector TempGamepadScreenDelta = Vector.Create();

		// Token: 0x04025CA9 RID: 154793
		public FVector2D TempActorScreenPos2D = new FVector2D();

		// Token: 0x04025CAA RID: 154794
		private bool DisableExit;
	}
}
