using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.Common.Event
{
	// Token: 0x02007071 RID: 28785
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class EventSystem : Singleton<EventSystem>
	{
		// Token: 0x06045BA6 RID: 285606 RVA: 0x0123EDD4 File Offset: 0x0123CFD4
		public bool Has(EEventName name, Delegate handle)
		{
			return this.EventInstance.Has(name, handle);
		}

		// Token: 0x06045BA7 RID: 285607 RVA: 0x0123EDE3 File Offset: 0x0123CFE3
		public bool Has(EEventName name, Action handle)
		{
			return this.Has(name, handle);
		}

		// Token: 0x06045BA8 RID: 285608 RVA: 0x0123EDED File Offset: 0x0123CFED
		public bool Has<[Nullable(2)] T1>(EEventName name, Action<T1> handle)
		{
			return this.Has(name, handle);
		}

		// Token: 0x06045BA9 RID: 285609 RVA: 0x0123EDF7 File Offset: 0x0123CFF7
		[NullableContext(2)]
		public bool Has<T1, T2>(EEventName name, [Nullable(1)] Action<T1, T2> handle)
		{
			return this.Has(name, handle);
		}

		// Token: 0x06045BAA RID: 285610 RVA: 0x0123EE01 File Offset: 0x0123D001
		[NullableContext(2)]
		public bool Has<T1, T2, T3>(EEventName name, [Nullable(1)] Action<T1, T2, T3> handle)
		{
			return this.Has(name, handle);
		}

		// Token: 0x06045BAB RID: 285611 RVA: 0x0123EE0B File Offset: 0x0123D00B
		[NullableContext(2)]
		public bool Has<T1, T2, T3, T4>(EEventName name, [Nullable(1)] Action<T1, T2, T3, T4> handle)
		{
			return this.Has(name, handle);
		}

		// Token: 0x06045BAC RID: 285612 RVA: 0x0123EE15 File Offset: 0x0123D015
		[NullableContext(2)]
		public bool Has<T1, T2, T3, T4, T5>(EEventName name, [Nullable(1)] Action<T1, T2, T3, T4, T5> handle)
		{
			return this.Has(name, handle);
		}

		// Token: 0x06045BAD RID: 285613 RVA: 0x0123EE1F File Offset: 0x0123D01F
		[NullableContext(2)]
		public bool Has<T1, T2, T3, T4, T5, T6>(EEventName name, [Nullable(1)] Action<T1, T2, T3, T4, T5, T6> handle)
		{
			return this.Has(name, handle);
		}

		// Token: 0x06045BAE RID: 285614 RVA: 0x0123EE29 File Offset: 0x0123D029
		[NullableContext(2)]
		public bool Has<T1, T2, T3, T4, T5, T6, T7>(EEventName name, [Nullable(1)] Action<T1, T2, T3, T4, T5, T6, T7> handle)
		{
			return this.Has(name, handle);
		}

		// Token: 0x06045BAF RID: 285615 RVA: 0x0123EE33 File Offset: 0x0123D033
		public bool HasAny(EEventName name)
		{
			return this.EventInstance.HasAny(name);
		}

		// Token: 0x06045BB0 RID: 285616 RVA: 0x0123EE44 File Offset: 0x0123D044
		public bool HasAnyWithTarget(object target, EEventName name)
		{
			Event<EEventName, Delegate> targetEvent = this.GetTargetEvent(target);
			return targetEvent != null && targetEvent.HasAny(name);
		}

		// Token: 0x06045BB1 RID: 285617 RVA: 0x0123EE65 File Offset: 0x0123D065
		public void RemoveTargetEvents(object target)
		{
			this.TargetEvents.Remove(target);
		}

		// Token: 0x06045BB2 RID: 285618 RVA: 0x0123EE74 File Offset: 0x0123D074
		public bool HasWithTarget(object target, EEventName name, Delegate handle)
		{
			Event<EEventName, Delegate> targetEvent = this.GetTargetEvent(target);
			return targetEvent != null && targetEvent.Has(name, handle);
		}

		// Token: 0x06045BB3 RID: 285619 RVA: 0x0123EE96 File Offset: 0x0123D096
		public bool HasWithTarget(object target, EEventName name, Action handle)
		{
			return this.HasWithTarget(target, name, handle);
		}

		// Token: 0x06045BB4 RID: 285620 RVA: 0x0123EEA1 File Offset: 0x0123D0A1
		public bool HasWithTarget<[Nullable(2)] T1>(object target, EEventName name, Action<T1> handle)
		{
			return this.HasWithTarget(target, name, handle);
		}

		// Token: 0x06045BB5 RID: 285621 RVA: 0x0123EEAC File Offset: 0x0123D0AC
		public bool HasWithTarget<[Nullable(2)] T1, [Nullable(2)] T2>(object target, EEventName name, Action<T1, T2> handle)
		{
			return this.HasWithTarget(target, name, handle);
		}

		// Token: 0x06045BB6 RID: 285622 RVA: 0x0123EEB7 File Offset: 0x0123D0B7
		[NullableContext(2)]
		public bool HasWithTarget<T1, T2, T3>([Nullable(1)] object target, EEventName name, [Nullable(1)] Action<T1, T2, T3> handle)
		{
			return this.HasWithTarget(target, name, handle);
		}

		// Token: 0x06045BB7 RID: 285623 RVA: 0x0123EEC2 File Offset: 0x0123D0C2
		[NullableContext(2)]
		public bool HasWithTarget<T1, T2, T3, T4>([Nullable(1)] object target, EEventName name, [Nullable(1)] Action<T1, T2, T3, T4> handle)
		{
			return this.HasWithTarget(target, name, handle);
		}

		// Token: 0x06045BB8 RID: 285624 RVA: 0x0123EECD File Offset: 0x0123D0CD
		[NullableContext(2)]
		public bool HasWithTarget<T1, T2, T3, T4, T5>([Nullable(1)] object target, EEventName name, [Nullable(1)] Action<T1, T2, T3, T4, T5> handle)
		{
			return this.HasWithTarget(target, name, handle);
		}

		// Token: 0x06045BB9 RID: 285625 RVA: 0x0123EED8 File Offset: 0x0123D0D8
		[NullableContext(2)]
		public bool HasWithTarget<T1, T2, T3, T4, T5, T6>([Nullable(1)] object target, EEventName name, [Nullable(1)] Action<T1, T2, T3, T4, T5, T6> handle)
		{
			return this.HasWithTarget(target, name, handle);
		}

		// Token: 0x06045BBA RID: 285626 RVA: 0x0123EEE3 File Offset: 0x0123D0E3
		[NullableContext(2)]
		public bool HasWithTarget<T1, T2, T3, T4, T5, T6, T7>([Nullable(1)] object target, EEventName name, [Nullable(1)] Action<T1, T2, T3, T4, T5, T6, T7> handle)
		{
			return this.HasWithTarget(target, name, handle);
		}

		// Token: 0x06045BBB RID: 285627 RVA: 0x0123EEEE File Offset: 0x0123D0EE
		public bool Add(EEventName name, Delegate handle)
		{
			return this.EventInstance.Add(name, handle);
		}

		// Token: 0x06045BBC RID: 285628 RVA: 0x0123EEFD File Offset: 0x0123D0FD
		public bool Add(EEventName name, GenericEventHandler handle)
		{
			return this.EventInstance.Add(name, handle);
		}

		// Token: 0x06045BBD RID: 285629 RVA: 0x0123EF0C File Offset: 0x0123D10C
		public bool AddWithTargetUseHoldKey(object key, object target, EEventName name, Delegate handle)
		{
			Event<EEventName, Delegate> orCreateTargetEvent = this.GetOrCreateTargetEvent(target);
			if (!orCreateTargetEvent.Add(name, handle))
			{
				return false;
			}
			List<IEventSystemCacheKeyNode> list;
			this.TargetToEventsKeyCache.TryGetValue(key, out list);
			if (list == null)
			{
				list = new List<IEventSystemCacheKeyNode>();
				this.TargetToEventsKeyCache.Set(key, list);
			}
			orCreateTargetEvent.AddHoldKeyHandle<EEventName>(name, key, handle);
			list.Add(new EventSystemCacheKeyNode
			{
				Key = key,
				Handle = handle,
				Target = target,
				EventName = name
			});
			return true;
		}

		// Token: 0x06045BBE RID: 285630 RVA: 0x0123EF86 File Offset: 0x0123D186
		public bool AddWithTarget(object target, EEventName name, Delegate handle)
		{
			return this.GetOrCreateTargetEvent(target).Add(name, handle);
		}

		// Token: 0x06045BBF RID: 285631 RVA: 0x0123EF96 File Offset: 0x0123D196
		public bool Once(EEventName name, Delegate handle)
		{
			return this.EventInstance.Once(name, handle);
		}

		// Token: 0x06045BC0 RID: 285632 RVA: 0x0123EFA5 File Offset: 0x0123D1A5
		public bool Once(EEventName name, Action handle)
		{
			return this.Once(name, handle);
		}

		// Token: 0x06045BC1 RID: 285633 RVA: 0x0123EFAF File Offset: 0x0123D1AF
		public bool Once<[Nullable(2)] T1>(EEventName name, Action<T1> handle)
		{
			return this.Once(name, handle);
		}

		// Token: 0x06045BC2 RID: 285634 RVA: 0x0123EFB9 File Offset: 0x0123D1B9
		[NullableContext(2)]
		public bool Once<T1, T2>(EEventName name, [Nullable(1)] Action<T1, T2> handle)
		{
			return this.Once(name, handle);
		}

		// Token: 0x06045BC3 RID: 285635 RVA: 0x0123EFC3 File Offset: 0x0123D1C3
		[NullableContext(2)]
		public bool Once<T1, T2, T3>(EEventName name, [Nullable(1)] Action<T1, T2, T3> handle)
		{
			return this.Once(name, handle);
		}

		// Token: 0x06045BC4 RID: 285636 RVA: 0x0123EFCD File Offset: 0x0123D1CD
		[NullableContext(2)]
		public bool Once<T1, T2, T3, T4>(EEventName name, [Nullable(1)] Action<T1, T2, T3, T4> handle)
		{
			return this.Once(name, handle);
		}

		// Token: 0x06045BC5 RID: 285637 RVA: 0x0123EFD7 File Offset: 0x0123D1D7
		[NullableContext(2)]
		public bool Once<T1, T2, T3, T4, T5>(EEventName name, [Nullable(1)] Action<T1, T2, T3, T4, T5> handle)
		{
			return this.Once(name, handle);
		}

		// Token: 0x06045BC6 RID: 285638 RVA: 0x0123EFE1 File Offset: 0x0123D1E1
		public bool OnceWithTarget(object target, EEventName name, Delegate handle)
		{
			return this.GetOrCreateTargetEvent(target).Once(name, handle);
		}

		// Token: 0x06045BC7 RID: 285639 RVA: 0x0123EFF1 File Offset: 0x0123D1F1
		public bool OnceWithTarget<[Nullable(2)] T1>(object target, EEventName name, Action<T1> handle)
		{
			return this.OnceWithTarget(target, name, handle);
		}

		// Token: 0x06045BC8 RID: 285640 RVA: 0x0123EFFC File Offset: 0x0123D1FC
		public bool OnceWithTarget<[Nullable(2)] T1, [Nullable(2)] T2>(object target, EEventName name, Action<T1, T2> handle)
		{
			return this.OnceWithTarget(target, name, handle);
		}

		// Token: 0x06045BC9 RID: 285641 RVA: 0x0123F007 File Offset: 0x0123D207
		[NullableContext(2)]
		public bool OnceWithTarget<T1, T2, T3>([Nullable(1)] object target, EEventName name, [Nullable(1)] Action<T1, T2, T3> handle)
		{
			return this.OnceWithTarget(target, name, handle);
		}

		// Token: 0x06045BCA RID: 285642 RVA: 0x0123F012 File Offset: 0x0123D212
		[NullableContext(2)]
		public bool OnceWithTarget<T1, T2, T3, T4>([Nullable(1)] object target, EEventName name, [Nullable(1)] Action<T1, T2, T3, T4> handle)
		{
			return this.OnceWithTarget(target, name, handle);
		}

		// Token: 0x06045BCB RID: 285643 RVA: 0x0123F01D File Offset: 0x0123D21D
		[NullableContext(2)]
		public bool OnceWithTarget<T1, T2, T3, T4, T5>([Nullable(1)] object target, EEventName name, [Nullable(1)] Action<T1, T2, T3, T4, T5> handle)
		{
			return this.OnceWithTarget(target, name, handle);
		}

		// Token: 0x06045BCC RID: 285644 RVA: 0x0123F028 File Offset: 0x0123D228
		public bool Remove(EEventName name, Delegate handle)
		{
			bool result = this.EventInstance.Remove(name, handle);
			if (!this.EventInstance.HasAny(name) && this.BridgeActionNames.Contains(name))
			{
				this.BridgeActionNames.Remove(name);
				EventSystemBridge.UnregisterEvent((uint)name);
			}
			return result;
		}

		// Token: 0x06045BCD RID: 285645 RVA: 0x0123F066 File Offset: 0x0123D266
		public bool Remove(EEventName name, GenericEventHandler handle)
		{
			return this.Remove(name, handle);
		}

		// Token: 0x06045BCE RID: 285646 RVA: 0x0123F070 File Offset: 0x0123D270
		public bool Remove(EEventName name, Action handle)
		{
			return this.Remove(name, handle);
		}

		// Token: 0x06045BCF RID: 285647 RVA: 0x0123F07A File Offset: 0x0123D27A
		public bool Remove<[Nullable(2)] T1>(EEventName name, Action<T1> handle)
		{
			return this.Remove(name, handle);
		}

		// Token: 0x06045BD0 RID: 285648 RVA: 0x0123F084 File Offset: 0x0123D284
		[NullableContext(2)]
		public bool Remove<T1, T2>(EEventName name, [Nullable(1)] Action<T1, T2> handle)
		{
			return this.Remove(name, handle);
		}

		// Token: 0x06045BD1 RID: 285649 RVA: 0x0123F08E File Offset: 0x0123D28E
		[NullableContext(2)]
		public bool Remove<T1, T2, T3>(EEventName name, [Nullable(1)] Action<T1, T2, T3> handle)
		{
			return this.Remove(name, handle);
		}

		// Token: 0x06045BD2 RID: 285650 RVA: 0x0123F098 File Offset: 0x0123D298
		[NullableContext(2)]
		public bool Remove<T1, T2, T3, T4>(EEventName name, [Nullable(1)] Action<T1, T2, T3, T4> handle)
		{
			return this.Remove(name, handle);
		}

		// Token: 0x06045BD3 RID: 285651 RVA: 0x0123F0A2 File Offset: 0x0123D2A2
		[NullableContext(2)]
		public bool Remove<T1, T2, T3, T4, T5>(EEventName name, [Nullable(1)] Action<T1, T2, T3, T4, T5> handle)
		{
			return this.Remove(name, handle);
		}

		// Token: 0x06045BD4 RID: 285652 RVA: 0x0123F0AC File Offset: 0x0123D2AC
		[NullableContext(2)]
		public bool Remove<T1, T2, T3, T4, T5, T6>(EEventName name, [Nullable(1)] Action<T1, T2, T3, T4, T5, T6> handle)
		{
			return this.Remove(name, handle);
		}

		// Token: 0x06045BD5 RID: 285653 RVA: 0x0123F0B6 File Offset: 0x0123D2B6
		[NullableContext(2)]
		public bool Remove<T1, T2, T3, T4, T5, T6, T7>(EEventName name, [Nullable(1)] Action<T1, T2, T3, T4, T5, T6, T7> handle)
		{
			return this.Remove(name, handle);
		}

		// Token: 0x06045BD6 RID: 285654 RVA: 0x0123F0C0 File Offset: 0x0123D2C0
		public bool RemoveWithTarget(object target, EEventName name, Delegate handle)
		{
			Event<EEventName, Delegate> targetEvent = this.GetTargetEvent(target);
			if (targetEvent != null)
			{
				if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
				{
					object holdKeyByHandle = targetEvent.GetHoldKeyByHandle(name, handle);
					if (holdKeyByHandle != null)
					{
						Singleton<EventSystem>.Instance.RemoveWithTargetUseKeyInternal(holdKeyByHandle, target, name, handle);
						targetEvent.RemoveHoldKeyHandle(name, handle);
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Event;
						ELogAuthor author = ELogAuthor.HJJ;
						string message = "事件系统调用错误,请使用[RemoveWithTargetUseKey]";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("target", target);
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						return true;
					}
				}
				return targetEvent.Remove(name, handle);
			}
			return false;
		}

		// Token: 0x06045BD7 RID: 285655 RVA: 0x0123F139 File Offset: 0x0123D339
		public bool RemoveWithTarget(object target, EEventName name, Action handle)
		{
			return this.RemoveWithTarget(target, name, handle);
		}

		// Token: 0x06045BD8 RID: 285656 RVA: 0x0123F144 File Offset: 0x0123D344
		public bool RemoveWithTarget<[Nullable(2)] T1>(object target, EEventName name, Action<T1> handle)
		{
			return this.RemoveWithTarget(target, name, handle);
		}

		// Token: 0x06045BD9 RID: 285657 RVA: 0x0123F14F File Offset: 0x0123D34F
		public bool RemoveWithTarget<[Nullable(2)] T1, [Nullable(2)] T2>(object target, EEventName name, Action<T1, T2> handle)
		{
			return this.RemoveWithTarget(target, name, handle);
		}

		// Token: 0x06045BDA RID: 285658 RVA: 0x0123F15A File Offset: 0x0123D35A
		[NullableContext(2)]
		public bool RemoveWithTarget<T1, T2, T3>([Nullable(1)] object target, EEventName name, [Nullable(1)] Action<T1, T2, T3> handle)
		{
			return this.RemoveWithTarget(target, name, handle);
		}

		// Token: 0x06045BDB RID: 285659 RVA: 0x0123F165 File Offset: 0x0123D365
		[NullableContext(2)]
		public bool RemoveWithTarget<T1, T2, T3, T4>([Nullable(1)] object target, EEventName name, [Nullable(1)] Action<T1, T2, T3, T4> handle)
		{
			return this.RemoveWithTarget(target, name, handle);
		}

		// Token: 0x06045BDC RID: 285660 RVA: 0x0123F170 File Offset: 0x0123D370
		[NullableContext(2)]
		public bool RemoveWithTarget<T1, T2, T3, T4, T5>([Nullable(1)] object target, EEventName name, [Nullable(1)] Action<T1, T2, T3, T4, T5> handle)
		{
			return this.RemoveWithTarget(target, name, handle);
		}

		// Token: 0x06045BDD RID: 285661 RVA: 0x0123F17B File Offset: 0x0123D37B
		[NullableContext(2)]
		public bool RemoveWithTarget<T1, T2, T3, T4, T5, T6>([Nullable(1)] object target, EEventName name, [Nullable(1)] Action<T1, T2, T3, T4, T5, T6> handle)
		{
			return this.RemoveWithTarget(target, name, handle);
		}

		// Token: 0x06045BDE RID: 285662 RVA: 0x0123F186 File Offset: 0x0123D386
		[NullableContext(2)]
		public bool RemoveWithTarget<T1, T2, T3, T4, T5, T6, T7>([Nullable(1)] object target, EEventName name, [Nullable(1)] Action<T1, T2, T3, T4, T5, T6, T7> handle)
		{
			return this.RemoveWithTarget(target, name, handle);
		}

		// Token: 0x06045BDF RID: 285663 RVA: 0x0123F194 File Offset: 0x0123D394
		private bool RemoveWithTargetUseKeyInternal(object key, object target, EEventName name, Delegate handle)
		{
			List<IEventSystemCacheKeyNode> list;
			this.TargetToEventsKeyCache.TryGetValue(key, out list);
			if (list == null)
			{
				return false;
			}
			for (int i = 0; i < list.Count; i++)
			{
				IEventSystemCacheKeyNode eventSystemCacheKeyNode = list[i];
				if (eventSystemCacheKeyNode.Handle == handle && eventSystemCacheKeyNode.EventName.Equals(name) && eventSystemCacheKeyNode.Target == target)
				{
					list.RemoveAt(i);
					Event<EEventName, Delegate> targetEvent = this.GetTargetEvent(target);
					if (targetEvent != null)
					{
						targetEvent.Remove(name, handle);
						targetEvent.RemoveHoldKeyHandle(name, handle);
					}
					if (list.Count == 0)
					{
						this.TargetToEventsKeyCache.Remove(key);
					}
					return true;
				}
			}
			return false;
		}

		// Token: 0x06045BE0 RID: 285664 RVA: 0x0123F249 File Offset: 0x0123D449
		public bool RemoveWithTargetUseKey(object key, object target, EEventName name, Delegate handle)
		{
			return this.RemoveWithTargetUseKeyInternal(key, target, name, handle);
		}

		// Token: 0x06045BE1 RID: 285665 RVA: 0x0123F256 File Offset: 0x0123D456
		public bool RemoveWithTargetUseKey<[Nullable(2)] T1>(object key, object target, EEventName name, Action<T1> handle)
		{
			return this.RemoveWithTargetUseKey(key, target, name, handle);
		}

		// Token: 0x06045BE2 RID: 285666 RVA: 0x0123F263 File Offset: 0x0123D463
		public bool RemoveWithTargetUseKey<[Nullable(2)] T1, [Nullable(2)] T2>(object key, object target, EEventName name, Action<T1, T2> handle)
		{
			return this.RemoveWithTargetUseKey(key, target, name, handle);
		}

		// Token: 0x06045BE3 RID: 285667 RVA: 0x0123F270 File Offset: 0x0123D470
		public bool RemoveWithTargetUseKey<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3>(object key, object target, EEventName name, Action<T1, T2, T3> handle)
		{
			return this.RemoveWithTargetUseKey(key, target, name, handle);
		}

		// Token: 0x06045BE4 RID: 285668 RVA: 0x0123F27D File Offset: 0x0123D47D
		[NullableContext(2)]
		public bool RemoveWithTargetUseKey<T1, T2, T3, T4>([Nullable(1)] object key, [Nullable(1)] object target, EEventName name, [Nullable(1)] Action<T1, T2, T3, T4> handle)
		{
			return this.RemoveWithTargetUseKey(key, target, name, handle);
		}

		// Token: 0x06045BE5 RID: 285669 RVA: 0x0123F28A File Offset: 0x0123D48A
		[NullableContext(2)]
		public bool RemoveWithTargetUseKey<T1, T2, T3, T4, T5>([Nullable(1)] object key, [Nullable(1)] object target, EEventName name, [Nullable(1)] Action<T1, T2, T3, T4, T5> handle)
		{
			return this.RemoveWithTargetUseKey(key, target, name, handle);
		}

		// Token: 0x06045BE6 RID: 285670 RVA: 0x0123F298 File Offset: 0x0123D498
		public bool RemoveAllTargetUseKey(object key)
		{
			List<IEventSystemCacheKeyNode> list;
			this.TargetToEventsKeyCache.TryGetValue(key, out list);
			if (list == null)
			{
				return false;
			}
			for (int i = 0; i < list.Count; i++)
			{
				IEventSystemCacheKeyNode eventSystemCacheKeyNode = list[i];
				Event<EEventName, Delegate> targetEvent = this.GetTargetEvent(eventSystemCacheKeyNode.Target);
				if (targetEvent != null)
				{
					targetEvent.Remove(eventSystemCacheKeyNode.EventName, eventSystemCacheKeyNode.Handle);
					targetEvent.RemoveHoldKeyHandle(eventSystemCacheKeyNode.EventName, eventSystemCacheKeyNode.Handle);
				}
			}
			this.TargetToEventsKeyCache.Remove(key);
			return true;
		}

		// Token: 0x06045BE7 RID: 285671 RVA: 0x0123F318 File Offset: 0x0123D518
		public bool Emit(EEventName name)
		{
			bool result;
			try
			{
				result = this.EventInstance.Emit(name);
			}
			catch (Exception error) when (1)
			{
				Singleton<Log>.Instance.ErrorWithStack(ELogModule.Event, ELogAuthor.WLJ, "[EventSystem::Emit]throw exception", error, default(ReadOnlySpan<ValueTuple<string, object>>));
				result = false;
			}
			return result;
		}

		// Token: 0x06045BE8 RID: 285672 RVA: 0x0123F37C File Offset: 0x0123D57C
		public bool Emit<[Nullable(2)] T1>(EEventName name, T1 p1)
		{
			bool result;
			try
			{
				result = this.EventInstance.Emit<T1>(name, p1);
			}
			catch (Exception error) when (1)
			{
				Singleton<Log>.Instance.ErrorWithStack(ELogModule.Event, ELogAuthor.WLJ, "[EventSystem::Emit<T>]throw exception", error, default(ReadOnlySpan<ValueTuple<string, object>>));
				result = false;
			}
			return result;
		}

		// Token: 0x06045BE9 RID: 285673 RVA: 0x0123F3E0 File Offset: 0x0123D5E0
		public bool Emit<[Nullable(2)] T1, [Nullable(2)] T2>(EEventName name, T1 p1, T2 p2)
		{
			bool result;
			try
			{
				result = this.EventInstance.Emit<T1, T2>(name, p1, p2);
			}
			catch (Exception error) when (1)
			{
				Singleton<Log>.Instance.ErrorWithStack(ELogModule.Event, ELogAuthor.WLJ, "[EventSystem::Emit<T1,T2>]throw exception", error, default(ReadOnlySpan<ValueTuple<string, object>>));
				result = false;
			}
			return result;
		}

		// Token: 0x06045BEA RID: 285674 RVA: 0x0123F444 File Offset: 0x0123D644
		public bool Emit<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3>(EEventName name, T1 p1, T2 p2, T3 p3)
		{
			bool result;
			try
			{
				result = this.EventInstance.Emit<T1, T2, T3>(name, p1, p2, p3);
			}
			catch (Exception error) when (1)
			{
				Singleton<Log>.Instance.ErrorWithStack(ELogModule.Event, ELogAuthor.WLJ, "[EventSystem::Emit<T1,T2,T3>]throw exception", error, default(ReadOnlySpan<ValueTuple<string, object>>));
				result = false;
			}
			return result;
		}

		// Token: 0x06045BEB RID: 285675 RVA: 0x0123F4AC File Offset: 0x0123D6AC
		public bool Emit<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4>(EEventName name, T1 p1, T2 p2, T3 p3, T4 p4)
		{
			bool result;
			try
			{
				result = this.EventInstance.Emit<T1, T2, T3, T4>(name, p1, p2, p3, p4);
			}
			catch (Exception error) when (1)
			{
				Singleton<Log>.Instance.ErrorWithStack(ELogModule.Event, ELogAuthor.WLJ, "[EventSystem::Emit<T1,T2,T3,T4>]throw exception", error, default(ReadOnlySpan<ValueTuple<string, object>>));
				result = false;
			}
			return result;
		}

		// Token: 0x06045BEC RID: 285676 RVA: 0x0123F514 File Offset: 0x0123D714
		public bool Emit<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4, [Nullable(2)] T5>(EEventName name, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
		{
			bool result;
			try
			{
				result = this.EventInstance.Emit<T1, T2, T3, T4, T5>(name, p1, p2, p3, p4, p5);
			}
			catch (Exception error) when (1)
			{
				Singleton<Log>.Instance.ErrorWithStack(ELogModule.Event, ELogAuthor.WLJ, "[EventSystem::Emit<T1,T2,T3,T4,T5>]throw exception", error, default(ReadOnlySpan<ValueTuple<string, object>>));
				result = false;
			}
			return result;
		}

		// Token: 0x06045BED RID: 285677 RVA: 0x0123F580 File Offset: 0x0123D780
		public bool Emit<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4, [Nullable(2)] T5, [Nullable(2)] T6>(EEventName name, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
		{
			bool result;
			try
			{
				result = this.EventInstance.Emit<T1, T2, T3, T4, T5, T6>(name, p1, p2, p3, p4, p5, p6);
			}
			catch (Exception error) when (1)
			{
				Singleton<Log>.Instance.ErrorWithStack(ELogModule.Event, ELogAuthor.WLJ, "[EventSystem::Emit<T1,T2,T3,T4,T5,T6>]throw exception", error, default(ReadOnlySpan<ValueTuple<string, object>>));
				result = false;
			}
			return result;
		}

		// Token: 0x06045BEE RID: 285678 RVA: 0x0123F5EC File Offset: 0x0123D7EC
		public bool Emit<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4, [Nullable(2)] T5, [Nullable(2)] T6, [Nullable(2)] T7>(EEventName name, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
		{
			bool result;
			try
			{
				result = this.EventInstance.Emit<T1, T2, T3, T4, T5, T6, T7>(name, p1, p2, p3, p4, p5, p6, p7);
			}
			catch (Exception error) when (1)
			{
				Singleton<Log>.Instance.ErrorWithStack(ELogModule.Event, ELogAuthor.WLJ, "[EventSystem::Emit<T1,T2,T3,T4,T5,T6,T7>]throw exception", error, default(ReadOnlySpan<ValueTuple<string, object>>));
				result = false;
			}
			return result;
		}

		// Token: 0x06045BEF RID: 285679 RVA: 0x0123F65C File Offset: 0x0123D85C
		public bool EmitWithTarget(object target, EEventName name)
		{
			bool result;
			try
			{
				Event<EEventName, Delegate> targetEvent = this.GetTargetEvent(target);
				result = (targetEvent != null && targetEvent.Emit(name));
			}
			catch (Exception error) when (1)
			{
				Singleton<Log>.Instance.ErrorWithStack(ELogModule.Event, ELogAuthor.WLJ, "[EventSystem::EmitWithTarget]throw exception", error, default(ReadOnlySpan<ValueTuple<string, object>>));
				result = false;
			}
			return result;
		}

		// Token: 0x06045BF0 RID: 285680 RVA: 0x0123F6C8 File Offset: 0x0123D8C8
		public bool EmitWithTarget<[Nullable(2)] T1>(object target, EEventName name, T1 p1)
		{
			bool result;
			try
			{
				Event<EEventName, Delegate> targetEvent = this.GetTargetEvent(target);
				result = (targetEvent != null && targetEvent.Emit<T1>(name, p1));
			}
			catch (Exception error) when (1)
			{
				Singleton<Log>.Instance.ErrorWithStack(ELogModule.Event, ELogAuthor.WLJ, "[EventSystem::EmitWithTarget<T1>]throw exception", error, default(ReadOnlySpan<ValueTuple<string, object>>));
				result = false;
			}
			return result;
		}

		// Token: 0x06045BF1 RID: 285681 RVA: 0x0123F734 File Offset: 0x0123D934
		public bool EmitWithTarget<[Nullable(2)] T1, [Nullable(2)] T2>(object target, EEventName name, T1 p1, T2 p2)
		{
			bool result;
			try
			{
				Event<EEventName, Delegate> targetEvent = this.GetTargetEvent(target);
				result = (targetEvent != null && targetEvent.Emit<T1, T2>(name, p1, p2));
			}
			catch (Exception error) when (1)
			{
				Singleton<Log>.Instance.ErrorWithStack(ELogModule.Event, ELogAuthor.WLJ, "[EventSystem::EmitWithTarget<T1,T2>]throw exception", error, default(ReadOnlySpan<ValueTuple<string, object>>));
				result = false;
			}
			return result;
		}

		// Token: 0x06045BF2 RID: 285682 RVA: 0x0123F7A4 File Offset: 0x0123D9A4
		public bool EmitWithTarget<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3>(object target, EEventName name, T1 p1, T2 p2, T3 p3)
		{
			bool result;
			try
			{
				Event<EEventName, Delegate> targetEvent = this.GetTargetEvent(target);
				result = (targetEvent != null && targetEvent.Emit<T1, T2, T3>(name, p1, p2, p3));
			}
			catch (Exception error) when (1)
			{
				Singleton<Log>.Instance.ErrorWithStack(ELogModule.Event, ELogAuthor.WLJ, "[EventSystem::EmitWithTarget<T1,T2,T3>]throw exception", error, default(ReadOnlySpan<ValueTuple<string, object>>));
				result = false;
			}
			return result;
		}

		// Token: 0x06045BF3 RID: 285683 RVA: 0x0123F814 File Offset: 0x0123DA14
		public bool EmitWithTarget<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4>(object target, EEventName name, T1 p1, T2 p2, T3 p3, T4 p4)
		{
			bool result;
			try
			{
				Event<EEventName, Delegate> targetEvent = this.GetTargetEvent(target);
				result = (targetEvent != null && targetEvent.Emit<T1, T2, T3, T4>(name, p1, p2, p3, p4));
			}
			catch (Exception error) when (1)
			{
				Singleton<Log>.Instance.ErrorWithStack(ELogModule.Event, ELogAuthor.WLJ, "[EventSystem::EmitWithTarget<T1,T2,T3,T4>]throw exception", error, default(ReadOnlySpan<ValueTuple<string, object>>));
				result = false;
			}
			return result;
		}

		// Token: 0x06045BF4 RID: 285684 RVA: 0x0123F888 File Offset: 0x0123DA88
		public bool EmitWithTarget<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4, [Nullable(2)] T5>(object target, EEventName name, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
		{
			bool result;
			try
			{
				Event<EEventName, Delegate> targetEvent = this.GetTargetEvent(target);
				result = (targetEvent != null && targetEvent.Emit<T1, T2, T3, T4, T5>(name, p1, p2, p3, p4, p5));
			}
			catch (Exception error) when (1)
			{
				Singleton<Log>.Instance.ErrorWithStack(ELogModule.Event, ELogAuthor.WLJ, "[EventSystem::EmitWithTarget<T1,T2,T3,T4,T5>]throw exception", error, default(ReadOnlySpan<ValueTuple<string, object>>));
				result = false;
			}
			return result;
		}

		// Token: 0x06045BF5 RID: 285685 RVA: 0x0123F8FC File Offset: 0x0123DAFC
		public bool EmitWithTarget<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4, [Nullable(2)] T5, [Nullable(2)] T6>(object target, EEventName name, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
		{
			bool result;
			try
			{
				Event<EEventName, Delegate> targetEvent = this.GetTargetEvent(target);
				result = (targetEvent != null && targetEvent.Emit<T1, T2, T3, T4, T5, T6>(name, p1, p2, p3, p4, p5, p6));
			}
			catch (Exception error) when (1)
			{
				Singleton<Log>.Instance.ErrorWithStack(ELogModule.Event, ELogAuthor.WLJ, "[EventSystem::EmitWithTarget<T1,T2,T3,T4,T5,T6>]throw exception", error, default(ReadOnlySpan<ValueTuple<string, object>>));
				result = false;
			}
			return result;
		}

		// Token: 0x06045BF6 RID: 285686 RVA: 0x0123F974 File Offset: 0x0123DB74
		public bool EmitWithTarget<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4, [Nullable(2)] T5, [Nullable(2)] T6, [Nullable(2)] T7>(object target, EEventName name, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
		{
			bool result;
			try
			{
				Event<EEventName, Delegate> targetEvent = this.GetTargetEvent(target);
				result = (targetEvent != null && targetEvent.Emit<T1, T2, T3, T4, T5, T6, T7>(name, p1, p2, p3, p4, p5, p6, p7));
			}
			catch (Exception error) when (1)
			{
				Singleton<Log>.Instance.ErrorWithStack(ELogModule.Event, ELogAuthor.WLJ, "[EventSystem::EmitWithTarget<T1,T2,T3,T4,T5,T6,T7>]throw exception", error, default(ReadOnlySpan<ValueTuple<string, object>>));
				result = false;
			}
			return result;
		}

		// Token: 0x06045BF7 RID: 285687 RVA: 0x0123F9EC File Offset: 0x0123DBEC
		public void EmitWithTargets([Nullable(new byte[]
		{
			2,
			1
		})] object[] targetList, EEventName name)
		{
			if (targetList == null || targetList.Length == 0)
			{
				return;
			}
			foreach (object target in targetList)
			{
				Event<EEventName, Delegate> targetEvent = this.GetTargetEvent(target);
				if (targetEvent != null)
				{
					targetEvent.Emit(name);
				}
			}
		}

		// Token: 0x06045BF8 RID: 285688 RVA: 0x0123FA2C File Offset: 0x0123DC2C
		public void EmitWithTargets<[Nullable(2)] T1>([Nullable(new byte[]
		{
			2,
			1
		})] object[] targetList, EEventName name, T1 p1)
		{
			if (targetList == null || targetList.Length == 0)
			{
				return;
			}
			foreach (object target in targetList)
			{
				Event<EEventName, Delegate> targetEvent = this.GetTargetEvent(target);
				if (targetEvent != null)
				{
					targetEvent.Emit<T1>(name, p1);
				}
			}
		}

		// Token: 0x06045BF9 RID: 285689 RVA: 0x0123FA6C File Offset: 0x0123DC6C
		public void EmitWithTargets<[Nullable(2)] T1, [Nullable(2)] T2>([Nullable(new byte[]
		{
			2,
			1
		})] object[] targetList, EEventName name, T1 p1, T2 p2)
		{
			if (targetList == null || targetList.Length == 0)
			{
				return;
			}
			foreach (object target in targetList)
			{
				Event<EEventName, Delegate> targetEvent = this.GetTargetEvent(target);
				if (targetEvent != null)
				{
					targetEvent.Emit<T1, T2>(name, p1, p2);
				}
			}
		}

		// Token: 0x06045BFA RID: 285690 RVA: 0x0123FAAC File Offset: 0x0123DCAC
		public void EmitWithTargets<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3>([Nullable(new byte[]
		{
			2,
			1
		})] object[] targetList, EEventName name, T1 p1, T2 p2, T3 p3)
		{
			if (targetList == null || targetList.Length == 0)
			{
				return;
			}
			foreach (object target in targetList)
			{
				Event<EEventName, Delegate> targetEvent = this.GetTargetEvent(target);
				if (targetEvent != null)
				{
					targetEvent.Emit<T1, T2, T3>(name, p1, p2, p3);
				}
			}
		}

		// Token: 0x06045BFB RID: 285691 RVA: 0x0123FAF0 File Offset: 0x0123DCF0
		public void EmitWithTargets<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4>([Nullable(new byte[]
		{
			2,
			1
		})] object[] targetList, EEventName name, T1 p1, T2 p2, T3 p3, T4 p4)
		{
			if (targetList == null || targetList.Length == 0)
			{
				return;
			}
			foreach (object target in targetList)
			{
				Event<EEventName, Delegate> targetEvent = this.GetTargetEvent(target);
				if (targetEvent != null)
				{
					targetEvent.Emit<T1, T2, T3, T4>(name, p1, p2, p3, p4);
				}
			}
		}

		// Token: 0x06045BFC RID: 285692 RVA: 0x0123FB34 File Offset: 0x0123DD34
		public void EmitWithTargets<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4, [Nullable(2)] T5>([Nullable(new byte[]
		{
			2,
			1
		})] object[] targetList, EEventName name, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
		{
			if (targetList == null || targetList.Length == 0)
			{
				return;
			}
			foreach (object target in targetList)
			{
				Event<EEventName, Delegate> targetEvent = this.GetTargetEvent(target);
				if (targetEvent != null)
				{
					targetEvent.Emit<T1, T2, T3, T4, T5>(name, p1, p2, p3, p4, p5);
				}
			}
		}

		// Token: 0x06045BFD RID: 285693 RVA: 0x0123FB7C File Offset: 0x0123DD7C
		[NullableContext(2)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private Event<EEventName, Delegate> GetTargetEvent(object target)
		{
			if (target == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.LCC;
				string message = "事件系统目标不存在，请检查目标";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("target", target);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			Event<EEventName, Delegate> result;
			this.TargetEvents.TryGetValue(target, out result);
			return result;
		}

		// Token: 0x06045BFE RID: 285694 RVA: 0x0123FBC4 File Offset: 0x0123DDC4
		private Event<EEventName, Delegate> GetOrCreateTargetEvent(object target)
		{
			Event<EEventName, Delegate> @event = this.GetTargetEvent(target);
			if (@event == null)
			{
				@event = new Event<EEventName, Delegate>();
				this.TargetEvents.Set(target, @event);
			}
			return @event;
		}

		// Token: 0x06045BFF RID: 285695 RVA: 0x0123FBF0 File Offset: 0x0123DDF0
		public bool Add(EEventName name, Action handle)
		{
			if (this.BridgeActionNames.Add(name))
			{
				Action<uint> eventAction;
				if ((eventAction = EventSystem.<>O.<0>__EmitFromBridge) == null)
				{
					eventAction = (EventSystem.<>O.<0>__EmitFromBridge = new Action<uint>(EventSystem.EmitFromBridge));
				}
				EventSystemBridge.RegisterEvent((uint)name, eventAction);
			}
			return this.Add(name, handle);
		}

		// Token: 0x06045C00 RID: 285696 RVA: 0x0123FC2C File Offset: 0x0123DE2C
		public bool Add<[Nullable(2)] T1>(EEventName name, Action<T1> handle)
		{
			if (this.BridgeActionNames.Add(name))
			{
				Action<uint, T1> eventAction;
				if ((eventAction = EventSystem.<Add>O__96_0<T1>.<0>__EmitFromBridge) == null)
				{
					Action<uint, T1> action = EventSystem.<Add>O__96_0<T1>.<0>__EmitFromBridge = new Action<uint, T1>(EventSystem.EmitFromBridge<T1>);
					eventAction = action;
				}
				EventSystemBridge.RegisterEvent<T1>((uint)name, eventAction);
			}
			return this.Add(name, handle);
		}

		// Token: 0x06045C01 RID: 285697 RVA: 0x0123FC74 File Offset: 0x0123DE74
		[NullableContext(2)]
		public bool Add<T1, T2>(EEventName name, [Nullable(1)] Action<T1, T2> handle)
		{
			if (this.BridgeActionNames.Add(name))
			{
				Action<uint, T1, T2> eventAction;
				if ((eventAction = EventSystem.<Add>O__97_0<T1, T2>.<0>__EmitFromBridge) == null)
				{
					Action<uint, T1, T2> action = EventSystem.<Add>O__97_0<T1, T2>.<0>__EmitFromBridge = new Action<uint, T1, T2>(EventSystem.EmitFromBridge<T1, T2>);
					eventAction = action;
				}
				EventSystemBridge.RegisterEvent<T1, T2>((uint)name, eventAction);
			}
			return this.Add(name, handle);
		}

		// Token: 0x06045C02 RID: 285698 RVA: 0x0123FCBC File Offset: 0x0123DEBC
		[NullableContext(2)]
		public bool Add<T1, T2, T3>(EEventName name, [Nullable(1)] Action<T1, T2, T3> handle)
		{
			if (this.BridgeActionNames.Add(name))
			{
				Action<uint, T1, T2, T3> eventAction;
				if ((eventAction = EventSystem.<Add>O__98_0<T1, T2, T3>.<0>__EmitFromBridge) == null)
				{
					Action<uint, T1, T2, T3> action = EventSystem.<Add>O__98_0<T1, T2, T3>.<0>__EmitFromBridge = new Action<uint, T1, T2, T3>(EventSystem.EmitFromBridge<T1, T2, T3>);
					eventAction = action;
				}
				EventSystemBridge.RegisterEvent<T1, T2, T3>((uint)name, eventAction);
			}
			return this.Add(name, handle);
		}

		// Token: 0x06045C03 RID: 285699 RVA: 0x0123FD04 File Offset: 0x0123DF04
		[NullableContext(2)]
		public bool Add<T1, T2, T3, T4>(EEventName name, [Nullable(1)] Action<T1, T2, T3, T4> handle)
		{
			if (this.BridgeActionNames.Add(name))
			{
				Action<uint, T1, T2, T3, T4> eventAction;
				if ((eventAction = EventSystem.<Add>O__99_0<T1, T2, T3, T4>.<0>__EmitFromBridge) == null)
				{
					Action<uint, T1, T2, T3, T4> action = EventSystem.<Add>O__99_0<T1, T2, T3, T4>.<0>__EmitFromBridge = new Action<uint, T1, T2, T3, T4>(EventSystem.EmitFromBridge<T1, T2, T3, T4>);
					eventAction = action;
				}
				EventSystemBridge.RegisterEvent<T1, T2, T3, T4>((uint)name, eventAction);
			}
			return this.Add(name, handle);
		}

		// Token: 0x06045C04 RID: 285700 RVA: 0x0123FD4C File Offset: 0x0123DF4C
		[NullableContext(2)]
		public bool Add<T1, T2, T3, T4, T5>(EEventName name, [Nullable(1)] Action<T1, T2, T3, T4, T5> handle)
		{
			if (this.BridgeActionNames.Add(name))
			{
				Action<uint, T1, T2, T3, T4, T5> eventAction;
				if ((eventAction = EventSystem.<Add>O__100_0<T1, T2, T3, T4, T5>.<0>__EmitFromBridge) == null)
				{
					Action<uint, T1, T2, T3, T4, T5> action = EventSystem.<Add>O__100_0<T1, T2, T3, T4, T5>.<0>__EmitFromBridge = new Action<uint, T1, T2, T3, T4, T5>(EventSystem.EmitFromBridge<T1, T2, T3, T4, T5>);
					eventAction = action;
				}
				EventSystemBridge.RegisterEvent<T1, T2, T3, T4, T5>((uint)name, eventAction);
			}
			return this.Add(name, handle);
		}

		// Token: 0x06045C05 RID: 285701 RVA: 0x0123FD94 File Offset: 0x0123DF94
		[NullableContext(2)]
		public bool Add<T1, T2, T3, T4, T5, T6>(EEventName name, [Nullable(1)] Action<T1, T2, T3, T4, T5, T6> handle)
		{
			if (this.BridgeActionNames.Add(name))
			{
				Action<uint, T1, T2, T3, T4, T5, T6> eventAction;
				if ((eventAction = EventSystem.<Add>O__101_0<T1, T2, T3, T4, T5, T6>.<0>__EmitFromBridge) == null)
				{
					Action<uint, T1, T2, T3, T4, T5, T6> action = EventSystem.<Add>O__101_0<T1, T2, T3, T4, T5, T6>.<0>__EmitFromBridge = new Action<uint, T1, T2, T3, T4, T5, T6>(EventSystem.EmitFromBridge<T1, T2, T3, T4, T5, T6>);
					eventAction = action;
				}
				EventSystemBridge.RegisterEvent<T1, T2, T3, T4, T5, T6>((uint)name, eventAction);
			}
			return this.Add(name, handle);
		}

		// Token: 0x06045C06 RID: 285702 RVA: 0x0123FDDC File Offset: 0x0123DFDC
		[NullableContext(2)]
		public bool Add<T1, T2, T3, T4, T5, T6, T7>(EEventName name, [Nullable(1)] Action<T1, T2, T3, T4, T5, T6, T7> handle)
		{
			if (this.BridgeActionNames.Add(name))
			{
				Action<uint, T1, T2, T3, T4, T5, T6, T7> eventAction;
				if ((eventAction = EventSystem.<Add>O__102_0<T1, T2, T3, T4, T5, T6, T7>.<0>__EmitFromBridge) == null)
				{
					Action<uint, T1, T2, T3, T4, T5, T6, T7> action = EventSystem.<Add>O__102_0<T1, T2, T3, T4, T5, T6, T7>.<0>__EmitFromBridge = new Action<uint, T1, T2, T3, T4, T5, T6, T7>(EventSystem.EmitFromBridge<T1, T2, T3, T4, T5, T6, T7>);
					eventAction = action;
				}
				EventSystemBridge.RegisterEvent<T1, T2, T3, T4, T5, T6, T7>((uint)name, eventAction);
			}
			return this.Add(name, handle);
		}

		// Token: 0x06045C07 RID: 285703 RVA: 0x0123FE24 File Offset: 0x0123E024
		public bool AddWithTarget(object target, EEventName name, Action handle)
		{
			if (target is Entity && this.BridgeActionWithTargetNames.Add(name))
			{
				Action<uint, int> eventAction;
				if ((eventAction = EventSystem.<>O.<1>__EmitWithTargetFromBridge) == null)
				{
					eventAction = (EventSystem.<>O.<1>__EmitWithTargetFromBridge = new Action<uint, int>(EventSystem.EmitWithTargetFromBridge));
				}
				EventSystemBridge.RegisterEventWithTarget((uint)name, eventAction);
			}
			return this.AddWithTarget(target, name, handle);
		}

		// Token: 0x06045C08 RID: 285704 RVA: 0x0123FE74 File Offset: 0x0123E074
		public bool AddWithTarget<[Nullable(2)] T1>(object target, EEventName name, Action<T1> handle)
		{
			if (target is Entity && this.BridgeActionWithTargetNames.Add(name))
			{
				Action<uint, int, T1> eventAction;
				if ((eventAction = EventSystem.<AddWithTarget>O__104_0<T1>.<0>__EmitWithTargetFromBridge) == null)
				{
					Action<uint, int, T1> action = EventSystem.<AddWithTarget>O__104_0<T1>.<0>__EmitWithTargetFromBridge = new Action<uint, int, T1>(EventSystem.EmitWithTargetFromBridge<T1>);
					eventAction = action;
				}
				EventSystemBridge.RegisterEventWithTarget<T1>((uint)name, eventAction);
			}
			return this.AddWithTarget(target, name, handle);
		}

		// Token: 0x06045C09 RID: 285705 RVA: 0x0123FEC4 File Offset: 0x0123E0C4
		public bool AddWithTarget<[Nullable(2)] T1, [Nullable(2)] T2>(object target, EEventName name, Action<T1, T2> handle)
		{
			if (target is Entity && this.BridgeActionWithTargetNames.Add(name))
			{
				Action<uint, int, T1, T2> eventAction;
				if ((eventAction = EventSystem.<AddWithTarget>O__105_0<T1, T2>.<0>__EmitWithTargetFromBridge) == null)
				{
					Action<uint, int, T1, T2> action = EventSystem.<AddWithTarget>O__105_0<T1, T2>.<0>__EmitWithTargetFromBridge = new Action<uint, int, T1, T2>(EventSystem.EmitWithTargetFromBridge<T1, T2>);
					eventAction = action;
				}
				EventSystemBridge.RegisterEventWithTarget<T1, T2>((uint)name, eventAction);
			}
			return this.AddWithTarget(target, name, handle);
		}

		// Token: 0x06045C0A RID: 285706 RVA: 0x0123FF14 File Offset: 0x0123E114
		[NullableContext(2)]
		public bool AddWithTarget<T1, T2, T3>([Nullable(1)] object target, EEventName name, [Nullable(1)] Action<T1, T2, T3> handle)
		{
			if (target is Entity && this.BridgeActionWithTargetNames.Add(name))
			{
				Action<uint, int, T1, T2, T3> eventAction;
				if ((eventAction = EventSystem.<AddWithTarget>O__106_0<T1, T2, T3>.<0>__EmitWithTargetFromBridge) == null)
				{
					Action<uint, int, T1, T2, T3> action = EventSystem.<AddWithTarget>O__106_0<T1, T2, T3>.<0>__EmitWithTargetFromBridge = new Action<uint, int, T1, T2, T3>(EventSystem.EmitWithTargetFromBridge<T1, T2, T3>);
					eventAction = action;
				}
				EventSystemBridge.RegisterEventWithTarget<T1, T2, T3>((uint)name, eventAction);
			}
			return this.AddWithTarget(target, name, handle);
		}

		// Token: 0x06045C0B RID: 285707 RVA: 0x0123FF64 File Offset: 0x0123E164
		[NullableContext(2)]
		public bool AddWithTarget<T1, T2, T3, T4>([Nullable(1)] object target, EEventName name, [Nullable(1)] Action<T1, T2, T3, T4> handle)
		{
			if (target is Entity && this.BridgeActionWithTargetNames.Add(name))
			{
				Action<uint, int, T1, T2, T3, T4> eventAction;
				if ((eventAction = EventSystem.<AddWithTarget>O__107_0<T1, T2, T3, T4>.<0>__EmitWithTargetFromBridge) == null)
				{
					Action<uint, int, T1, T2, T3, T4> action = EventSystem.<AddWithTarget>O__107_0<T1, T2, T3, T4>.<0>__EmitWithTargetFromBridge = new Action<uint, int, T1, T2, T3, T4>(EventSystem.EmitWithTargetFromBridge<T1, T2, T3, T4>);
					eventAction = action;
				}
				EventSystemBridge.RegisterEventWithTarget<T1, T2, T3, T4>((uint)name, eventAction);
			}
			return this.AddWithTarget(target, name, handle);
		}

		// Token: 0x06045C0C RID: 285708 RVA: 0x0123FFB4 File Offset: 0x0123E1B4
		[NullableContext(2)]
		public bool AddWithTarget<T1, T2, T3, T4, T5>([Nullable(1)] object target, EEventName name, [Nullable(1)] Action<T1, T2, T3, T4, T5> handle)
		{
			if (target is Entity && this.BridgeActionWithTargetNames.Add(name))
			{
				Action<uint, int, T1, T2, T3, T4, T5> eventAction;
				if ((eventAction = EventSystem.<AddWithTarget>O__108_0<T1, T2, T3, T4, T5>.<0>__EmitWithTargetFromBridge) == null)
				{
					Action<uint, int, T1, T2, T3, T4, T5> action = EventSystem.<AddWithTarget>O__108_0<T1, T2, T3, T4, T5>.<0>__EmitWithTargetFromBridge = new Action<uint, int, T1, T2, T3, T4, T5>(EventSystem.EmitWithTargetFromBridge<T1, T2, T3, T4, T5>);
					eventAction = action;
				}
				EventSystemBridge.RegisterEventWithTarget<T1, T2, T3, T4, T5>((uint)name, eventAction);
			}
			return this.AddWithTarget(target, name, handle);
		}

		// Token: 0x06045C0D RID: 285709 RVA: 0x01240004 File Offset: 0x0123E204
		[NullableContext(2)]
		public bool AddWithTarget<T1, T2, T3, T4, T5, T6>([Nullable(1)] object target, EEventName name, [Nullable(1)] Action<T1, T2, T3, T4, T5, T6> handle)
		{
			if (target is Entity && this.BridgeActionWithTargetNames.Add(name))
			{
				Action<uint, int, T1, T2, T3, T4, T5, T6> eventAction;
				if ((eventAction = EventSystem.<AddWithTarget>O__109_0<T1, T2, T3, T4, T5, T6>.<0>__EmitWithTargetFromBridge) == null)
				{
					Action<uint, int, T1, T2, T3, T4, T5, T6> action = EventSystem.<AddWithTarget>O__109_0<T1, T2, T3, T4, T5, T6>.<0>__EmitWithTargetFromBridge = new Action<uint, int, T1, T2, T3, T4, T5, T6>(EventSystem.EmitWithTargetFromBridge<T1, T2, T3, T4, T5, T6>);
					eventAction = action;
				}
				EventSystemBridge.RegisterEventWithTarget<T1, T2, T3, T4, T5, T6>((uint)name, eventAction);
			}
			return this.AddWithTarget(target, name, handle);
		}

		// Token: 0x06045C0E RID: 285710 RVA: 0x01240054 File Offset: 0x0123E254
		[NullableContext(2)]
		public bool AddWithTarget<T1, T2, T3, T4, T5, T6, T7>([Nullable(1)] object target, EEventName name, [Nullable(1)] Action<T1, T2, T3, T4, T5, T6, T7> handle)
		{
			if (target is Entity && this.BridgeActionWithTargetNames.Add(name))
			{
				Action<uint, int, T1, T2, T3, T4, T5, T6> eventAction;
				if ((eventAction = EventSystem.<AddWithTarget>O__110_0<T1, T2, T3, T4, T5, T6, T7>.<0>__EmitWithTargetFromBridge) == null)
				{
					Action<uint, int, T1, T2, T3, T4, T5, T6> action = EventSystem.<AddWithTarget>O__110_0<T1, T2, T3, T4, T5, T6, T7>.<0>__EmitWithTargetFromBridge = new Action<uint, int, T1, T2, T3, T4, T5, T6>(EventSystem.EmitWithTargetFromBridge<T1, T2, T3, T4, T5, T6>);
					eventAction = action;
				}
				EventSystemBridge.RegisterEventWithTarget<T1, T2, T3, T4, T5, T6>((uint)name, eventAction);
			}
			return this.AddWithTarget(target, name, handle);
		}

		// Token: 0x06045C0F RID: 285711 RVA: 0x012400A4 File Offset: 0x0123E2A4
		public bool AddWithTargetUseHoldKey(object key, object target, EEventName name, Action handle)
		{
			if (target is Entity && this.BridgeActionWithTargetNames.Add(name))
			{
				Action<uint, int> eventAction;
				if ((eventAction = EventSystem.<>O.<1>__EmitWithTargetFromBridge) == null)
				{
					eventAction = (EventSystem.<>O.<1>__EmitWithTargetFromBridge = new Action<uint, int>(EventSystem.EmitWithTargetFromBridge));
				}
				EventSystemBridge.RegisterEventWithTarget((uint)name, eventAction);
			}
			return this.AddWithTargetUseHoldKey(key, target, name, handle);
		}

		// Token: 0x06045C10 RID: 285712 RVA: 0x012400F4 File Offset: 0x0123E2F4
		public bool AddWithTargetUseHoldKey<[Nullable(2)] T1>(object key, object target, EEventName name, Action<T1> handle)
		{
			if (target is Entity && this.BridgeActionWithTargetNames.Add(name))
			{
				Action<uint, int, T1> eventAction;
				if ((eventAction = EventSystem.<AddWithTargetUseHoldKey>O__112_0<T1>.<0>__EmitWithTargetFromBridge) == null)
				{
					Action<uint, int, T1> action = EventSystem.<AddWithTargetUseHoldKey>O__112_0<T1>.<0>__EmitWithTargetFromBridge = new Action<uint, int, T1>(EventSystem.EmitWithTargetFromBridge<T1>);
					eventAction = action;
				}
				EventSystemBridge.RegisterEventWithTarget<T1>((uint)name, eventAction);
			}
			return this.AddWithTargetUseHoldKey(key, target, name, handle);
		}

		// Token: 0x06045C11 RID: 285713 RVA: 0x01240148 File Offset: 0x0123E348
		public bool AddWithTargetUseHoldKey<[Nullable(2)] T1, [Nullable(2)] T2>(object key, object target, EEventName name, Action<T1, T2> handle)
		{
			if (target is Entity && this.BridgeActionWithTargetNames.Add(name))
			{
				Action<uint, int, T1, T2> eventAction;
				if ((eventAction = EventSystem.<AddWithTargetUseHoldKey>O__113_0<T1, T2>.<0>__EmitWithTargetFromBridge) == null)
				{
					Action<uint, int, T1, T2> action = EventSystem.<AddWithTargetUseHoldKey>O__113_0<T1, T2>.<0>__EmitWithTargetFromBridge = new Action<uint, int, T1, T2>(EventSystem.EmitWithTargetFromBridge<T1, T2>);
					eventAction = action;
				}
				EventSystemBridge.RegisterEventWithTarget<T1, T2>((uint)name, eventAction);
			}
			return this.AddWithTargetUseHoldKey(key, target, name, handle);
		}

		// Token: 0x06045C12 RID: 285714 RVA: 0x0124019C File Offset: 0x0123E39C
		public bool AddWithTargetUseHoldKey<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3>(object key, object target, EEventName name, Action<T1, T2, T3> handle)
		{
			if (target is Entity && this.BridgeActionWithTargetNames.Add(name))
			{
				Action<uint, int, T1, T2, T3> eventAction;
				if ((eventAction = EventSystem.<AddWithTargetUseHoldKey>O__114_0<T1, T2, T3>.<0>__EmitWithTargetFromBridge) == null)
				{
					Action<uint, int, T1, T2, T3> action = EventSystem.<AddWithTargetUseHoldKey>O__114_0<T1, T2, T3>.<0>__EmitWithTargetFromBridge = new Action<uint, int, T1, T2, T3>(EventSystem.EmitWithTargetFromBridge<T1, T2, T3>);
					eventAction = action;
				}
				EventSystemBridge.RegisterEventWithTarget<T1, T2, T3>((uint)name, eventAction);
			}
			return this.AddWithTargetUseHoldKey(key, target, name, handle);
		}

		// Token: 0x06045C13 RID: 285715 RVA: 0x012401F0 File Offset: 0x0123E3F0
		[NullableContext(2)]
		public bool AddWithTargetUseHoldKey<T1, T2, T3, T4>([Nullable(1)] object key, [Nullable(1)] object target, EEventName name, [Nullable(1)] Action<T1, T2, T3, T4> handle)
		{
			if (target is Entity && this.BridgeActionWithTargetNames.Add(name))
			{
				Action<uint, int, T1, T2, T3, T4> eventAction;
				if ((eventAction = EventSystem.<AddWithTargetUseHoldKey>O__115_0<T1, T2, T3, T4>.<0>__EmitWithTargetFromBridge) == null)
				{
					Action<uint, int, T1, T2, T3, T4> action = EventSystem.<AddWithTargetUseHoldKey>O__115_0<T1, T2, T3, T4>.<0>__EmitWithTargetFromBridge = new Action<uint, int, T1, T2, T3, T4>(EventSystem.EmitWithTargetFromBridge<T1, T2, T3, T4>);
					eventAction = action;
				}
				EventSystemBridge.RegisterEventWithTarget<T1, T2, T3, T4>((uint)name, eventAction);
			}
			return this.AddWithTargetUseHoldKey(key, target, name, handle);
		}

		// Token: 0x06045C14 RID: 285716 RVA: 0x01240244 File Offset: 0x0123E444
		[NullableContext(2)]
		public bool AddWithTargetUseHoldKey<T1, T2, T3, T4, T5>([Nullable(1)] object key, [Nullable(1)] object target, EEventName name, [Nullable(1)] Action<T1, T2, T3, T4, T5> handle)
		{
			if (target is Entity && this.BridgeActionWithTargetNames.Add(name))
			{
				Action<uint, int, T1, T2, T3, T4, T5> eventAction;
				if ((eventAction = EventSystem.<AddWithTargetUseHoldKey>O__116_0<T1, T2, T3, T4, T5>.<0>__EmitWithTargetFromBridge) == null)
				{
					Action<uint, int, T1, T2, T3, T4, T5> action = EventSystem.<AddWithTargetUseHoldKey>O__116_0<T1, T2, T3, T4, T5>.<0>__EmitWithTargetFromBridge = new Action<uint, int, T1, T2, T3, T4, T5>(EventSystem.EmitWithTargetFromBridge<T1, T2, T3, T4, T5>);
					eventAction = action;
				}
				EventSystemBridge.RegisterEventWithTarget<T1, T2, T3, T4, T5>((uint)name, eventAction);
			}
			return this.AddWithTargetUseHoldKey(key, target, name, handle);
		}

		// Token: 0x06045C15 RID: 285717 RVA: 0x01240298 File Offset: 0x0123E498
		[NullableContext(2)]
		public bool AddWithTargetUseHoldKey<T1, T2, T3, T4, T5, T6>([Nullable(1)] object key, [Nullable(1)] object target, EEventName name, [Nullable(1)] Action<T1, T2, T3, T4, T5, T6> handle)
		{
			if (target is Entity && this.BridgeActionWithTargetNames.Add(name))
			{
				Action<uint, int, T1, T2, T3, T4, T5, T6> eventAction;
				if ((eventAction = EventSystem.<AddWithTargetUseHoldKey>O__117_0<T1, T2, T3, T4, T5, T6>.<0>__EmitWithTargetFromBridge) == null)
				{
					Action<uint, int, T1, T2, T3, T4, T5, T6> action = EventSystem.<AddWithTargetUseHoldKey>O__117_0<T1, T2, T3, T4, T5, T6>.<0>__EmitWithTargetFromBridge = new Action<uint, int, T1, T2, T3, T4, T5, T6>(EventSystem.EmitWithTargetFromBridge<T1, T2, T3, T4, T5, T6>);
					eventAction = action;
				}
				EventSystemBridge.RegisterEventWithTarget<T1, T2, T3, T4, T5, T6>((uint)name, eventAction);
			}
			return this.AddWithTargetUseHoldKey(key, target, name, handle);
		}

		// Token: 0x06045C16 RID: 285718 RVA: 0x012402EC File Offset: 0x0123E4EC
		[NullableContext(2)]
		public bool AddWithTargetUseHoldKey<T1, T2, T3, T4, T5, T6, T7>([Nullable(1)] object key, [Nullable(1)] object target, EEventName name, [Nullable(1)] Action<T1, T2, T3, T4, T5, T6, T7> handle)
		{
			if (target is Entity && this.BridgeActionWithTargetNames.Add(name))
			{
				Action<uint, int, T1, T2, T3, T4, T5, T6, T7> eventAction;
				if ((eventAction = EventSystem.<AddWithTargetUseHoldKey>O__118_0<T1, T2, T3, T4, T5, T6, T7>.<0>__EmitWithTargetFromBridge) == null)
				{
					Action<uint, int, T1, T2, T3, T4, T5, T6, T7> action = EventSystem.<AddWithTargetUseHoldKey>O__118_0<T1, T2, T3, T4, T5, T6, T7>.<0>__EmitWithTargetFromBridge = new Action<uint, int, T1, T2, T3, T4, T5, T6, T7>(EventSystem.EmitWithTargetFromBridge<T1, T2, T3, T4, T5, T6, T7>);
					eventAction = action;
				}
				EventSystemBridge.RegisterEventWithTarget<T1, T2, T3, T4, T5, T6, T7>((uint)name, eventAction);
			}
			return this.AddWithTargetUseHoldKey(key, target, name, handle);
		}

		// Token: 0x06045C17 RID: 285719 RVA: 0x0124033D File Offset: 0x0123E53D
		private static void EmitFromBridge(uint name)
		{
			Singleton<EventSystem>.Instance.EventInstance.Emit((EEventName)name);
		}

		// Token: 0x06045C18 RID: 285720 RVA: 0x01240350 File Offset: 0x0123E550
		private static void EmitFromBridge<[Nullable(2)] T1>(uint name, T1 p1)
		{
			Singleton<EventSystem>.Instance.EventInstance.Emit<T1>((EEventName)name, p1);
		}

		// Token: 0x06045C19 RID: 285721 RVA: 0x01240364 File Offset: 0x0123E564
		private static void EmitFromBridge<[Nullable(2)] T1, [Nullable(2)] T2>(uint name, T1 p1, T2 p2)
		{
			Singleton<EventSystem>.Instance.EventInstance.Emit<T1, T2>((EEventName)name, p1, p2);
		}

		// Token: 0x06045C1A RID: 285722 RVA: 0x01240379 File Offset: 0x0123E579
		private static void EmitFromBridge<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3>(uint name, T1 p1, T2 p2, T3 p3)
		{
			Singleton<EventSystem>.Instance.EventInstance.Emit<T1, T2, T3>((EEventName)name, p1, p2, p3);
		}

		// Token: 0x06045C1B RID: 285723 RVA: 0x0124038F File Offset: 0x0123E58F
		private static void EmitFromBridge<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4>(uint name, T1 p1, T2 p2, T3 p3, T4 p4)
		{
			Singleton<EventSystem>.Instance.EventInstance.Emit<T1, T2, T3, T4>((EEventName)name, p1, p2, p3, p4);
		}

		// Token: 0x06045C1C RID: 285724 RVA: 0x012403A7 File Offset: 0x0123E5A7
		private static void EmitFromBridge<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4, [Nullable(2)] T5>(uint name, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
		{
			Singleton<EventSystem>.Instance.EventInstance.Emit<T1, T2, T3, T4, T5>((EEventName)name, p1, p2, p3, p4, p5);
		}

		// Token: 0x06045C1D RID: 285725 RVA: 0x012403C1 File Offset: 0x0123E5C1
		private static void EmitFromBridge<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4, [Nullable(2)] T5, [Nullable(2)] T6>(uint name, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
		{
			Singleton<EventSystem>.Instance.EventInstance.Emit<T1, T2, T3, T4, T5, T6>((EEventName)name, p1, p2, p3, p4, p5, p6);
		}

		// Token: 0x06045C1E RID: 285726 RVA: 0x012403E0 File Offset: 0x0123E5E0
		private static void EmitFromBridge<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4, [Nullable(2)] T5, [Nullable(2)] T6, [Nullable(2)] T7>(uint name, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
		{
			Singleton<EventSystem>.Instance.EventInstance.Emit<T1, T2, T3, T4, T5, T6, T7>((EEventName)name, p1, p2, p3, p4, p5, p6, p7);
		}

		// Token: 0x06045C1F RID: 285727 RVA: 0x0124040C File Offset: 0x0123E60C
		private static void EmitWithTargetFromBridge(uint name, int targetId)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get<Entity>(targetId);
			if (entity != null)
			{
				Event<EEventName, Delegate> targetEvent = Singleton<EventSystem>.Instance.GetTargetEvent(entity);
				if (targetEvent == null)
				{
					return;
				}
				targetEvent.Emit((EEventName)name);
			}
		}

		// Token: 0x06045C20 RID: 285728 RVA: 0x01240440 File Offset: 0x0123E640
		private static void EmitWithTargetFromBridge<[Nullable(2)] T1>(uint name, int targetId, T1 p1)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get<Entity>(targetId);
			if (entity != null)
			{
				Event<EEventName, Delegate> targetEvent = Singleton<EventSystem>.Instance.GetTargetEvent(entity);
				if (targetEvent == null)
				{
					return;
				}
				targetEvent.Emit<T1>((EEventName)name, p1);
			}
		}

		// Token: 0x06045C21 RID: 285729 RVA: 0x01240474 File Offset: 0x0123E674
		private static void EmitWithTargetFromBridge<[Nullable(2)] T1, [Nullable(2)] T2>(uint name, int targetId, T1 p1, T2 p2)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get<Entity>(targetId);
			if (entity != null)
			{
				Event<EEventName, Delegate> targetEvent = Singleton<EventSystem>.Instance.GetTargetEvent(entity);
				if (targetEvent == null)
				{
					return;
				}
				targetEvent.Emit<T1, T2>((EEventName)name, p1, p2);
			}
		}

		// Token: 0x06045C22 RID: 285730 RVA: 0x012404AC File Offset: 0x0123E6AC
		private static void EmitWithTargetFromBridge<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3>(uint name, int targetId, T1 p1, T2 p2, T3 p3)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get<Entity>(targetId);
			if (entity != null)
			{
				Event<EEventName, Delegate> targetEvent = Singleton<EventSystem>.Instance.GetTargetEvent(entity);
				if (targetEvent == null)
				{
					return;
				}
				targetEvent.Emit<T1, T2, T3>((EEventName)name, p1, p2, p3);
			}
		}

		// Token: 0x06045C23 RID: 285731 RVA: 0x012404E4 File Offset: 0x0123E6E4
		private static void EmitWithTargetFromBridge<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4>(uint name, int targetId, T1 p1, T2 p2, T3 p3, T4 p4)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get<Entity>(targetId);
			if (entity != null)
			{
				Event<EEventName, Delegate> targetEvent = Singleton<EventSystem>.Instance.GetTargetEvent(entity);
				if (targetEvent == null)
				{
					return;
				}
				targetEvent.Emit<T1, T2, T3, T4>((EEventName)name, p1, p2, p3, p4);
			}
		}

		// Token: 0x06045C24 RID: 285732 RVA: 0x01240520 File Offset: 0x0123E720
		private static void EmitWithTargetFromBridge<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4, [Nullable(2)] T5>(uint name, int targetId, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get<Entity>(targetId);
			if (entity != null)
			{
				Event<EEventName, Delegate> targetEvent = Singleton<EventSystem>.Instance.GetTargetEvent(entity);
				if (targetEvent == null)
				{
					return;
				}
				targetEvent.Emit<T1, T2, T3, T4, T5>((EEventName)name, p1, p2, p3, p4, p5);
			}
		}

		// Token: 0x06045C25 RID: 285733 RVA: 0x0124055C File Offset: 0x0123E75C
		private static void EmitWithTargetFromBridge<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4, [Nullable(2)] T5, [Nullable(2)] T6>(uint name, int targetId, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get<Entity>(targetId);
			if (entity != null)
			{
				Event<EEventName, Delegate> targetEvent = Singleton<EventSystem>.Instance.GetTargetEvent(entity);
				if (targetEvent == null)
				{
					return;
				}
				targetEvent.Emit<T1, T2, T3, T4, T5, T6>((EEventName)name, p1, p2, p3, p4, p5, p6);
			}
		}

		// Token: 0x06045C26 RID: 285734 RVA: 0x0124059C File Offset: 0x0123E79C
		private static void EmitWithTargetFromBridge<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4, [Nullable(2)] T5, [Nullable(2)] T6, [Nullable(2)] T7>(uint name, int targetId, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get<Entity>(targetId);
			if (entity != null)
			{
				Event<EEventName, Delegate> targetEvent = Singleton<EventSystem>.Instance.GetTargetEvent(entity);
				if (targetEvent == null)
				{
					return;
				}
				targetEvent.Emit<T1, T2, T3, T4, T5, T6, T7>((EEventName)name, p1, p2, p3, p4, p5, p6, p7);
			}
		}

		// Token: 0x06045C27 RID: 285735 RVA: 0x012405DC File Offset: 0x0123E7DC
		public bool AddWithCondition<[Nullable(2)] T1>(EEventName name, Action<T1> handle, T1 conditionParam)
		{
			if (conditionParam == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "添加条件监听事件时，条件参数为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", name);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			return this.EventInstance.AddWithCondition<T1>(name, handle, conditionParam);
		}

		// Token: 0x06045C28 RID: 285736 RVA: 0x01240630 File Offset: 0x0123E830
		public bool OnceWithCondition<[Nullable(2)] T1>(EEventName name, Action<T1> handle, T1 conditionParam)
		{
			if (conditionParam == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "添加一次性条件监听事件时，条件参数为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", name);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			return this.EventInstance.OnceWithCondition<T1>(name, handle, conditionParam);
		}

		// Token: 0x06045C29 RID: 285737 RVA: 0x01240684 File Offset: 0x0123E884
		public bool RemoveWithCondition<[Nullable(2)] T1>(EEventName name, Action<T1> handle, T1 conditionParam)
		{
			if (conditionParam == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "移除条件监听事件时，条件参数为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", name);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			return this.EventInstance.RemoveWithCondition<T1>(name, handle, conditionParam);
		}

		// Token: 0x06045C2A RID: 285738 RVA: 0x012406D8 File Offset: 0x0123E8D8
		public bool HasWithCondition<[Nullable(2)] T1>(EEventName name, Action<T1> handle, T1 conditionParam)
		{
			if (conditionParam == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "检查条件监听事件时，条件参数为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", name);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			return this.EventInstance.HasWithCondition<T1>(name, handle, conditionParam);
		}

		// Token: 0x04027079 RID: 159865
		private readonly HashSet<EEventName> BridgeActionNames = new HashSet<EEventName>();

		// Token: 0x0402707A RID: 159866
		private readonly HashSet<EEventName> BridgeActionWithTargetNames = new HashSet<EEventName>();

		// Token: 0x0402707B RID: 159867
		private readonly Event<EEventName, Delegate> EventInstance = new Event<EEventName, Delegate>();

		// Token: 0x0402707C RID: 159868
		private readonly WeakMap<object, Event<EEventName, Delegate>> TargetEvents = new WeakMap<object, Event<EEventName, Delegate>>();

		// Token: 0x0402707D RID: 159869
		private readonly WeakMap<object, List<IEventSystemCacheKeyNode>> TargetToEventsKeyCache = new WeakMap<object, List<IEventSystemCacheKeyNode>>();

		// Token: 0x0402707E RID: 159870
		private readonly Stat RemoveStat = Stat.Create("EventSystem.RemoveWithTargetUseKey", "", "");

		// Token: 0x0200CC93 RID: 52371
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403EC58 RID: 257112
			[Nullable(0)]
			public static Action<uint> <0>__EmitFromBridge;

			// Token: 0x0403EC59 RID: 257113
			[Nullable(0)]
			public static Action<uint, int> <1>__EmitWithTargetFromBridge;
		}

		// Token: 0x0200CC94 RID: 52372
		[CompilerGenerated]
		private static class <Add>O__100_0<T1, T2, T3, T4, T5>
		{
			// Token: 0x0403EC5A RID: 257114
			[Nullable(0)]
			public static Action<uint, T1, T2, T3, T4, T5> <0>__EmitFromBridge;
		}

		// Token: 0x0200CC95 RID: 52373
		[CompilerGenerated]
		private static class <Add>O__101_0<T1, T2, T3, T4, T5, T6>
		{
			// Token: 0x0403EC5B RID: 257115
			[Nullable(0)]
			public static Action<uint, T1, T2, T3, T4, T5, T6> <0>__EmitFromBridge;
		}

		// Token: 0x0200CC96 RID: 52374
		[CompilerGenerated]
		private static class <Add>O__102_0<T1, T2, T3, T4, T5, T6, T7>
		{
			// Token: 0x0403EC5C RID: 257116
			[Nullable(0)]
			public static Action<uint, T1, T2, T3, T4, T5, T6, T7> <0>__EmitFromBridge;
		}

		// Token: 0x0200CC97 RID: 52375
		[CompilerGenerated]
		private static class <Add>O__96_0<T1>
		{
			// Token: 0x0403EC5D RID: 257117
			[Nullable(0)]
			public static Action<uint, T1> <0>__EmitFromBridge;
		}

		// Token: 0x0200CC98 RID: 52376
		[CompilerGenerated]
		private static class <Add>O__97_0<T1, T2>
		{
			// Token: 0x0403EC5E RID: 257118
			[Nullable(0)]
			public static Action<uint, T1, T2> <0>__EmitFromBridge;
		}

		// Token: 0x0200CC99 RID: 52377
		[CompilerGenerated]
		private static class <Add>O__98_0<T1, T2, T3>
		{
			// Token: 0x0403EC5F RID: 257119
			[Nullable(0)]
			public static Action<uint, T1, T2, T3> <0>__EmitFromBridge;
		}

		// Token: 0x0200CC9A RID: 52378
		[CompilerGenerated]
		private static class <Add>O__99_0<T1, T2, T3, T4>
		{
			// Token: 0x0403EC60 RID: 257120
			[Nullable(0)]
			public static Action<uint, T1, T2, T3, T4> <0>__EmitFromBridge;
		}

		// Token: 0x0200CC9B RID: 52379
		[CompilerGenerated]
		private static class <AddWithTarget>O__104_0<T1>
		{
			// Token: 0x0403EC61 RID: 257121
			[Nullable(0)]
			public static Action<uint, int, T1> <0>__EmitWithTargetFromBridge;
		}

		// Token: 0x0200CC9C RID: 52380
		[CompilerGenerated]
		private static class <AddWithTarget>O__105_0<T1, T2>
		{
			// Token: 0x0403EC62 RID: 257122
			[Nullable(0)]
			public static Action<uint, int, T1, T2> <0>__EmitWithTargetFromBridge;
		}

		// Token: 0x0200CC9D RID: 52381
		[CompilerGenerated]
		private static class <AddWithTarget>O__106_0<T1, T2, T3>
		{
			// Token: 0x0403EC63 RID: 257123
			[Nullable(0)]
			public static Action<uint, int, T1, T2, T3> <0>__EmitWithTargetFromBridge;
		}

		// Token: 0x0200CC9E RID: 52382
		[CompilerGenerated]
		private static class <AddWithTarget>O__107_0<T1, T2, T3, T4>
		{
			// Token: 0x0403EC64 RID: 257124
			[Nullable(0)]
			public static Action<uint, int, T1, T2, T3, T4> <0>__EmitWithTargetFromBridge;
		}

		// Token: 0x0200CC9F RID: 52383
		[CompilerGenerated]
		private static class <AddWithTarget>O__108_0<T1, T2, T3, T4, T5>
		{
			// Token: 0x0403EC65 RID: 257125
			[Nullable(0)]
			public static Action<uint, int, T1, T2, T3, T4, T5> <0>__EmitWithTargetFromBridge;
		}

		// Token: 0x0200CCA0 RID: 52384
		[CompilerGenerated]
		private static class <AddWithTarget>O__109_0<T1, T2, T3, T4, T5, T6>
		{
			// Token: 0x0403EC66 RID: 257126
			[Nullable(0)]
			public static Action<uint, int, T1, T2, T3, T4, T5, T6> <0>__EmitWithTargetFromBridge;
		}

		// Token: 0x0200CCA1 RID: 52385
		[CompilerGenerated]
		private static class <AddWithTarget>O__110_0<T1, T2, T3, T4, T5, T6, T7>
		{
			// Token: 0x0403EC67 RID: 257127
			[Nullable(0)]
			public static Action<uint, int, T1, T2, T3, T4, T5, T6> <0>__EmitWithTargetFromBridge;
		}

		// Token: 0x0200CCA2 RID: 52386
		[CompilerGenerated]
		private static class <AddWithTargetUseHoldKey>O__112_0<T1>
		{
			// Token: 0x0403EC68 RID: 257128
			[Nullable(0)]
			public static Action<uint, int, T1> <0>__EmitWithTargetFromBridge;
		}

		// Token: 0x0200CCA3 RID: 52387
		[CompilerGenerated]
		private static class <AddWithTargetUseHoldKey>O__113_0<T1, T2>
		{
			// Token: 0x0403EC69 RID: 257129
			[Nullable(0)]
			public static Action<uint, int, T1, T2> <0>__EmitWithTargetFromBridge;
		}

		// Token: 0x0200CCA4 RID: 52388
		[CompilerGenerated]
		private static class <AddWithTargetUseHoldKey>O__114_0<T1, T2, T3>
		{
			// Token: 0x0403EC6A RID: 257130
			[Nullable(0)]
			public static Action<uint, int, T1, T2, T3> <0>__EmitWithTargetFromBridge;
		}

		// Token: 0x0200CCA5 RID: 52389
		[CompilerGenerated]
		private static class <AddWithTargetUseHoldKey>O__115_0<T1, T2, T3, T4>
		{
			// Token: 0x0403EC6B RID: 257131
			[Nullable(0)]
			public static Action<uint, int, T1, T2, T3, T4> <0>__EmitWithTargetFromBridge;
		}

		// Token: 0x0200CCA6 RID: 52390
		[CompilerGenerated]
		private static class <AddWithTargetUseHoldKey>O__116_0<T1, T2, T3, T4, T5>
		{
			// Token: 0x0403EC6C RID: 257132
			[Nullable(0)]
			public static Action<uint, int, T1, T2, T3, T4, T5> <0>__EmitWithTargetFromBridge;
		}

		// Token: 0x0200CCA7 RID: 52391
		[CompilerGenerated]
		private static class <AddWithTargetUseHoldKey>O__117_0<T1, T2, T3, T4, T5, T6>
		{
			// Token: 0x0403EC6D RID: 257133
			[Nullable(0)]
			public static Action<uint, int, T1, T2, T3, T4, T5, T6> <0>__EmitWithTargetFromBridge;
		}

		// Token: 0x0200CCA8 RID: 52392
		[CompilerGenerated]
		private static class <AddWithTargetUseHoldKey>O__118_0<T1, T2, T3, T4, T5, T6, T7>
		{
			// Token: 0x0403EC6E RID: 257134
			[Nullable(0)]
			public static Action<uint, int, T1, T2, T3, T4, T5, T6, T7> <0>__EmitWithTargetFromBridge;
		}
	}
}
