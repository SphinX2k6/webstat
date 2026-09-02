using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006095 RID: 24725
	[NullableContext(1)]
	[Nullable(0)]
	public class ScanTrackedMarksView : BattleChildView
	{
		// Token: 0x0603E65D RID: 255581 RVA: 0x00FF04D9 File Offset: 0x00FEE6D9
		[NullableContext(2)]
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			this.BindEvents();
		}

		// Token: 0x0603E65E RID: 255582 RVA: 0x00FF04E8 File Offset: 0x00FEE6E8
		public override void Reset()
		{
			base.Reset();
			this.UnbindEvents();
			this.TrackedMarks.Clear();
		}

		// Token: 0x0603E65F RID: 255583 RVA: 0x00FF0504 File Offset: 0x00FEE704
		public void Update()
		{
			foreach (ScanTrackedMarks scanTrackedMarks in this.TrackedMarks.Values)
			{
				scanTrackedMarks.Update();
			}
		}

		// Token: 0x0603E660 RID: 255584 RVA: 0x00FF055C File Offset: 0x00FEE75C
		[NullableContext(2)]
		private void ScanTrackedStart(int entityId, IScanCompositeResult scanComposite)
		{
			ScanTrackedMarksView.<>c__DisplayClass5_0 CS$<>8__locals1 = new ScanTrackedMarksView.<>c__DisplayClass5_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.entityId = entityId;
			if (scanComposite == null || scanComposite.ScanInfos.Count <= 0)
			{
				return;
			}
			CS$<>8__locals1.entity = Singleton<EntitySystem>.Instance.Get(CS$<>8__locals1.entityId);
			if (CS$<>8__locals1.entity == null)
			{
				return;
			}
			this.TrackedMarksLoaded.Add(CS$<>8__locals1.entityId);
			ScanTrackedMarksView.<>c__DisplayClass5_0 CS$<>8__locals2 = CS$<>8__locals1;
			BaseActorComponent component = CS$<>8__locals1.entity.GetComponent<BaseActorComponent>();
			CS$<>8__locals2.actor = ((component != null) ? component.Owner : null);
			CS$<>8__locals1.showDistance = scanComposite.ScanCompositeConfig.ShowDistance;
			CS$<>8__locals1.needClampToEllipse = scanComposite.ScanCompositeConfig.ClampToEllipse;
			using (List<GamePlayScan>.Enumerator enumerator = scanComposite.ScanInfos.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					GamePlayScan scanInfoConfig = enumerator.Current;
					int level = scanInfoConfig.Color;
					if (scanInfoConfig.IconPath.Length != 0)
					{
						Singleton<ResourceSystem>.Instance.LoadAsync<ULGUISpriteData_BaseObject>(scanInfoConfig.IconPath, delegate([Nullable(2)] ULGUISpriteData_BaseObject sprite, string _)
						{
							if (sprite == null || !sprite.IsValid())
							{
								return;
							}
							if (CS$<>8__locals1.actor == null)
							{
								return;
							}
							if (!CS$<>8__locals1.<>4__this.TrackedMarksLoaded.Contains(CS$<>8__locals1.entityId))
							{
								return;
							}
							global::Vector vector = global::Vector.Create(scanInfoConfig.Offset);
							BaseActorComponent component2 = CS$<>8__locals1.entity.GetComponent<BaseActorComponent>();
							Singleton<GravityUtils>.Instance.RotatedVectorByActorInitGravity(component2, vector);
							CS$<>8__locals1.<>4__this.InnerAddTrackMark(CS$<>8__locals1.entityId, sprite, 0f, string.Empty, null, CS$<>8__locals1.actor, global::Vector.Create(vector), new int?(level), new bool?(CS$<>8__locals1.showDistance), new bool?(CS$<>8__locals1.needClampToEllipse));
						}, 100, "js_undefined");
						break;
					}
				}
			}
		}

		// Token: 0x0603E661 RID: 255585 RVA: 0x00FF06A4 File Offset: 0x00FEE8A4
		private void ScanTrackedEnd(int entityId)
		{
			this.TrackedMarksLoaded.Remove(entityId);
			ScanTrackedMarks scanTrackedMarks;
			if (this.TrackedMarks.Remove(entityId, out scanTrackedMarks))
			{
				scanTrackedMarks.ToClose();
			}
		}

		// Token: 0x0603E662 RID: 255586 RVA: 0x00FF06D4 File Offset: 0x00FEE8D4
		private void InnerAddTrackMark(int id, ULGUISpriteData_BaseObject markIconSprite, float markHideDis, string effectPath, FVectorDouble? originPosition = null, [Nullable(2)] AActor trackActor = null, [Nullable(2)] global::Vector offset = null, int? level = null, bool? showDistance = null, bool? needClampToEllipse = null)
		{
			if (!this.TrackedMarks.ContainsKey(id))
			{
				ScanTrackedMarks value = new ScanTrackedMarks(this.RootItem, markIconSprite, markHideDis, effectPath, originPosition, trackActor, offset, level, showDistance, needClampToEllipse);
				this.TrackedMarks[id] = value;
			}
		}

		// Token: 0x0603E663 RID: 255587 RVA: 0x00FF0718 File Offset: 0x00FEE918
		private void BindEvents()
		{
			Singleton<EventSystem>.Instance.Add<int, IScanCompositeResult>(EEventName.ScanTrackedStart, new Action<int, IScanCompositeResult>(this.ScanTrackedStart));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.ScanTrackedEnd, new Action<int>(this.ScanTrackedEnd));
		}

		// Token: 0x0603E664 RID: 255588 RVA: 0x00FF0752 File Offset: 0x00FEE952
		private void UnbindEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.ScanTrackedStart, new Action<int, IScanCompositeResult>(this.ScanTrackedStart));
			Singleton<EventSystem>.Instance.Remove(EEventName.ScanTrackedEnd, new Action<int>(this.ScanTrackedEnd));
		}

		// Token: 0x0603E665 RID: 255589 RVA: 0x00FF078C File Offset: 0x00FEE98C
		protected override bool DestroyOverride()
		{
			return true;
		}

		// Token: 0x04022F86 RID: 143238
		private readonly Dictionary<int, ScanTrackedMarks> TrackedMarks = new Dictionary<int, ScanTrackedMarks>();

		// Token: 0x04022F87 RID: 143239
		private readonly HashSet<int> TrackedMarksLoaded = new HashSet<int>();
	}
}
