using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Capability.Editor;
using UnrealEngine;

namespace CSharpScript.Game.Capability
{
	// Token: 0x02007074 RID: 28788
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class CapabilityController : ControllerBase<CapabilityController>
	{
		// Token: 0x06045C42 RID: 285762 RVA: 0x01240973 File Offset: 0x0123EB73
		public CapabilityDebugger GetDebugger()
		{
			return ModelBase<CapabilityModel>.Instance.Debugger;
		}

		// Token: 0x06045C43 RID: 285763 RVA: 0x0124097F File Offset: 0x0123EB7F
		protected override bool OnClear()
		{
			this.UnregisterAllTickGroups();
			CapabilityModel instance = ModelBase<CapabilityModel>.Instance;
			if (instance != null)
			{
				instance.GroupScheduleCache.Clear();
			}
			if (instance != null)
			{
				instance.BumpScheduleGeneration();
			}
			return true;
		}

		// Token: 0x06045C44 RID: 285764 RVA: 0x012409A9 File Offset: 0x0123EBA9
		public void RegisterGameObject(ICapabilityGameObject go)
		{
			ModelBase<CapabilityModel>.Instance.GameObjects.Add(go);
			ModelBase<CapabilityModel>.Instance.BumpScheduleGeneration();
		}

		// Token: 0x06045C45 RID: 285765 RVA: 0x012409C6 File Offset: 0x0123EBC6
		public void UnregisterGameObject(ICapabilityGameObject go)
		{
			ModelBase<CapabilityModel>.Instance.GameObjects.Remove(go);
			ModelBase<CapabilityModel>.Instance.BumpScheduleGeneration();
		}

		// Token: 0x06045C46 RID: 285766 RVA: 0x012409E4 File Offset: 0x0123EBE4
		public void OnCapabilityAdded(Capability cap)
		{
			this.GetDebugger().LogEvent(Singleton<Time>.Instance.NowSeconds, cap, CapabilityCommonDefine.ECapabilityDebugEvent.Setup, null, null);
			this.EnsureTickGroupRegisteredFor(cap);
			ModelBase<CapabilityModel>.Instance.BumpScheduleGeneration();
		}

		// Token: 0x06045C47 RID: 285767 RVA: 0x01240A24 File Offset: 0x0123EC24
		public void OnCapabilityRemoved(Capability cap)
		{
			CapabilityDebugger debugger = this.GetDebugger();
			if (cap.IsActive())
			{
				debugger.LogEvent(Singleton<Time>.Instance.NowSeconds, cap, CapabilityCommonDefine.ECapabilityDebugEvent.OnDeactivated, "removed", null);
				debugger.EndActiveSpan(Singleton<Time>.Instance.NowSeconds, cap);
			}
			ModelBase<CapabilityModel>.Instance.BumpScheduleGeneration();
		}

		// Token: 0x06045C48 RID: 285768 RVA: 0x01240A7C File Offset: 0x0123EC7C
		public void OnCapabilityBlocked(Capability cap, int tag)
		{
			CapabilityDebugger debugger = this.GetDebugger();
			debugger.LogEvent(Singleton<Time>.Instance.NowSeconds, cap, CapabilityCommonDefine.ECapabilityDebugEvent.Blocked, GameplayTagUtils.GetNameByTagId(tag), null);
			if (cap.IsActive())
			{
				debugger.EndActiveSpan(Singleton<Time>.Instance.NowSeconds, cap);
			}
		}

		// Token: 0x06045C49 RID: 285769 RVA: 0x01240ACC File Offset: 0x0123ECCC
		public void OnCapabilityUnblocked(Capability cap, int tag)
		{
			this.GetDebugger().LogEvent(Singleton<Time>.Instance.NowSeconds, cap, CapabilityCommonDefine.ECapabilityDebugEvent.Unblocked, GameplayTagUtils.GetNameByTagId(tag), null);
		}

		// Token: 0x06045C4A RID: 285770 RVA: 0x01240B00 File Offset: 0x0123ED00
		protected override void OnTick(float deltaMilliseconds)
		{
			if (!Singleton<Info>.Instance.IsBuildShipping)
			{
				if (ModelBase<SundryModel>.Instance.GetModuleDebugLevel("Capability") > 0)
				{
					CapabilityTimelineDebugger timelineDebugger = ModelBase<CapabilityModel>.Instance.TimelineDebugger;
					if (timelineDebugger == null)
					{
						return;
					}
					timelineDebugger.Show();
					return;
				}
				else
				{
					CapabilityTimelineDebugger timelineDebugger2 = ModelBase<CapabilityModel>.Instance.TimelineDebugger;
					if (timelineDebugger2 == null)
					{
						return;
					}
					timelineDebugger2.Hide();
				}
			}
		}

		// Token: 0x06045C4B RID: 285771 RVA: 0x01240B54 File Offset: 0x0123ED54
		public void TickHostDefaultGroup(ICapabilityGameObject host, float deltaMilliseconds)
		{
			if (!host.IsValid())
			{
				return;
			}
			List<IScheduledEntry> orBuildHostDefaultSchedule = this.GetOrBuildHostDefaultSchedule(host);
			if (orBuildHostDefaultSchedule.Count == 0)
			{
				return;
			}
			this.RunSchedule(orBuildHostDefaultSchedule, deltaMilliseconds);
		}

		// Token: 0x06045C4C RID: 285772 RVA: 0x01240B84 File Offset: 0x0123ED84
		public void TickGroup(ETickingGroup group, float deltaMilliseconds)
		{
			List<IScheduledEntry> orBuildGroupSchedule = this.GetOrBuildGroupSchedule(group);
			if (orBuildGroupSchedule.Count == 0)
			{
				return;
			}
			this.RunSchedule(orBuildGroupSchedule, deltaMilliseconds);
		}

		// Token: 0x06045C4D RID: 285773 RVA: 0x01240BAC File Offset: 0x0123EDAC
		private List<IScheduledEntry> GetOrBuildGroupSchedule(ETickingGroup group)
		{
			CapabilityModel instance = ModelBase<CapabilityModel>.Instance;
			if (instance.GroupScheduleCacheGeneration == instance.ScheduleGeneration)
			{
				List<IScheduledEntry> valueOrDefault = instance.GroupScheduleCache.GetValueOrDefault(group);
				if (valueOrDefault != null)
				{
					return valueOrDefault;
				}
			}
			else
			{
				instance.GroupScheduleCache.Clear();
				instance.GroupScheduleCacheGeneration = instance.ScheduleGeneration;
			}
			List<IScheduledEntry> list = new List<IScheduledEntry>();
			foreach (ICapabilityGameObject capabilityGameObject in instance.GameObjects)
			{
				if (capabilityGameObject.IsValid())
				{
					foreach (Capability cap in capabilityGameObject.GetCapabilities().Values)
					{
						ScheduledEntry scheduledEntry = this.MakeScheduledEntry(cap);
						ETickingGroup? effectiveGroup = scheduledEntry.EffectiveGroup;
						if (effectiveGroup.GetValueOrDefault() == group & effectiveGroup != null)
						{
							list.Add(scheduledEntry);
						}
					}
				}
			}
			list.Sort((IScheduledEntry a, IScheduledEntry b) => a.EffectiveOrder - b.EffectiveOrder);
			instance.GroupScheduleCache[group] = list;
			return list;
		}

		// Token: 0x06045C4E RID: 285774 RVA: 0x01240CF0 File Offset: 0x0123EEF0
		private List<IScheduledEntry> GetOrBuildHostDefaultSchedule(ICapabilityGameObject host)
		{
			CapabilityModel instance = ModelBase<CapabilityModel>.Instance;
			HostDefaultScheduleCacheEntry hostDefaultScheduleCacheEntry;
			if (instance.HostDefaultScheduleCache.TryGetValue(host, out hostDefaultScheduleCacheEntry) && hostDefaultScheduleCacheEntry.Generation == instance.ScheduleGeneration)
			{
				return hostDefaultScheduleCacheEntry.Schedule;
			}
			List<IScheduledEntry> list = new List<IScheduledEntry>();
			foreach (Capability cap in host.GetCapabilities().Values)
			{
				ScheduledEntry scheduledEntry = this.MakeScheduledEntry(cap);
				if (scheduledEntry.EffectiveGroup == null)
				{
					list.Add(scheduledEntry);
				}
			}
			list.Sort((IScheduledEntry a, IScheduledEntry b) => a.EffectiveOrder - b.EffectiveOrder);
			instance.HostDefaultScheduleCache.Set(host, new HostDefaultScheduleCacheEntry
			{
				Generation = instance.ScheduleGeneration,
				Schedule = list
			});
			return list;
		}

		// Token: 0x06045C4F RID: 285775 RVA: 0x01240DDC File Offset: 0x0123EFDC
		private void RunSchedule(List<IScheduledEntry> schedule, float deltaMilliseconds)
		{
			foreach (IScheduledEntry scheduledEntry in schedule)
			{
				double now = Singleton<Time>.Instance.Now;
				try
				{
					scheduledEntry.Cap.PreTick(deltaMilliseconds);
				}
				catch (Exception err)
				{
					this.LogError("PreTick", scheduledEntry.Cap, err);
				}
				this.GetDebugger().LogEvent(Singleton<Time>.Instance.NowSeconds, scheduledEntry.Cap, CapabilityCommonDefine.ECapabilityDebugEvent.PreTick, null, new double?(Singleton<Time>.Instance.Now - now));
			}
			foreach (IScheduledEntry scheduledEntry2 in schedule)
			{
				Capability cap = scheduledEntry2.Cap;
				if (cap.IsActive())
				{
					this.TickActiveCapability(cap, deltaMilliseconds);
				}
				else
				{
					this.TryActivateCapability(cap, deltaMilliseconds);
				}
			}
		}

		// Token: 0x06045C50 RID: 285776 RVA: 0x01240EE4 File Offset: 0x0123F0E4
		private void EnsureTickGroupRegisteredFor(Capability cap)
		{
			ICapabilityConfig config = cap.GetConfig();
			if (config.TickGroup != null)
			{
				this.EnsureTickGroupRegistered(config.TickGroup.Value);
			}
			if (config.InactiveTickGroup != null)
			{
				this.EnsureTickGroupRegistered(config.InactiveTickGroup.Value);
			}
		}

		// Token: 0x06045C51 RID: 285777 RVA: 0x01240F40 File Offset: 0x0123F140
		private void EnsureTickGroupRegistered(ETickingGroup group)
		{
			CapabilityModel instance = ModelBase<CapabilityModel>.Instance;
			if (instance.RegisteredTickGroups.ContainsKey(group))
			{
				return;
			}
			string text;
			if ((text = CapabilityCommonDefine.ueTickingGroupName.GetValueOrDefault(group)) == null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Group");
				defaultInterpolatedStringHandler.AppendFormatted<ETickingGroup>(group);
				text = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			string str = text;
			Action<float> handle = delegate(float deltaMilliseconds)
			{
				this.TickGroup(group, deltaMilliseconds);
			};
			Ticker ticker = Singleton<TickSystem>.Instance.Add(handle, "Capability_" + str, group, false, 0, false);
			if (ticker != null)
			{
				instance.RegisteredTickGroups[group] = ticker.Id;
			}
		}

		// Token: 0x06045C52 RID: 285778 RVA: 0x01241004 File Offset: 0x0123F204
		private void UnregisterAllTickGroups()
		{
			CapabilityModel instance = ModelBase<CapabilityModel>.Instance;
			foreach (int id in instance.RegisteredTickGroups.Values)
			{
				Singleton<TickSystem>.Instance.Remove(id);
			}
			instance.RegisteredTickGroups.Clear();
		}

		// Token: 0x06045C53 RID: 285779 RVA: 0x01241074 File Offset: 0x0123F274
		private ScheduledEntry MakeScheduledEntry(Capability cap)
		{
			ICapabilityConfig config = cap.GetConfig();
			bool flag = !cap.IsActive() && config.InactiveTickGroup != null && config.InactiveTickGroupOrder != null;
			return new ScheduledEntry
			{
				Cap = cap,
				EffectiveGroup = (flag ? config.InactiveTickGroup : config.TickGroup),
				EffectiveOrder = (flag ? config.InactiveTickGroupOrder.Value : config.TickGroupOrder)
			};
		}

		// Token: 0x06045C54 RID: 285780 RVA: 0x012410F4 File Offset: 0x0123F2F4
		private void TryActivateCapability(Capability cap, float dt)
		{
			if (cap.IsBlocked())
			{
				return;
			}
			CapabilityDebugger debugger = this.GetDebugger();
			bool flag = false;
			try
			{
				flag = cap.ShouldActivate();
			}
			catch (Exception err)
			{
				this.LogError("ShouldActivate", cap, err);
			}
			debugger.LogEvent(Singleton<Time>.Instance.NowSeconds, cap, CapabilityCommonDefine.ECapabilityDebugEvent.ShouldActivate, flag ? "true" : "false", null);
			if (!flag)
			{
				return;
			}
			List<int> interruptsTags = cap.GetConfig().InterruptsTags;
			if (interruptsTags.Count > 0)
			{
				this.InterruptByTags(cap, interruptsTags);
			}
			try
			{
				cap.OnActivated();
			}
			catch (Exception err2)
			{
				this.LogError("OnActivated", cap, err2);
			}
			cap.InternalSetActive();
			ModelBase<CapabilityModel>.Instance.BumpScheduleGeneration();
			debugger.LogEvent(Singleton<Time>.Instance.NowSeconds, cap, CapabilityCommonDefine.ECapabilityDebugEvent.OnActivated, null, null);
			debugger.BeginActiveSpan(Singleton<Time>.Instance.NowSeconds, cap);
			this.TickActiveCapability(cap, dt);
		}

		// Token: 0x06045C55 RID: 285781 RVA: 0x012411F8 File Offset: 0x0123F3F8
		private void InterruptByTags(Capability activator, IReadOnlyList<int> interruptTags)
		{
			CapabilityDebugger debugger = this.GetDebugger();
			ICapabilityGameObject ownerGameObject = activator.OwnerGameObject;
			foreach (Capability capability in (((ownerGameObject != null) ? ownerGameObject.GetCapabilities().Values : null) ?? new List<Capability>()))
			{
				if (capability != activator && capability.IsActive())
				{
					List<int> tags = capability.GetConfig().Tags;
					bool flag = false;
					foreach (int item in interruptTags)
					{
						if (tags.Contains(item))
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						debugger.LogEvent(Singleton<Time>.Instance.NowSeconds, capability, CapabilityCommonDefine.ECapabilityDebugEvent.Interrupted, activator.GetCapabilityId(), null);
						try
						{
							capability.OnDeactivated();
						}
						catch (Exception err)
						{
							this.LogError("OnDeactivated(Interrupt)", capability, err);
						}
						capability.InternalSetDeactivated();
						ModelBase<CapabilityModel>.Instance.BumpScheduleGeneration();
						debugger.EndActiveSpan(Singleton<Time>.Instance.NowSeconds, capability);
					}
				}
			}
		}

		// Token: 0x06045C56 RID: 285782 RVA: 0x0124133C File Offset: 0x0123F53C
		private void TickActiveCapability(Capability cap, float dt)
		{
			CapabilityDebugger debugger = this.GetDebugger();
			bool flag = false;
			try
			{
				flag = cap.ShouldDeactivate();
			}
			catch (Exception err)
			{
				this.LogError("ShouldDeactivate", cap, err);
			}
			debugger.LogEvent(Singleton<Time>.Instance.NowSeconds, cap, CapabilityCommonDefine.ECapabilityDebugEvent.ShouldDeactivate, flag ? "true" : "false", null);
			if (flag)
			{
				try
				{
					cap.OnDeactivated();
				}
				catch (Exception err2)
				{
					this.LogError("OnDeactivated", cap, err2);
				}
				cap.InternalSetDeactivated();
				ModelBase<CapabilityModel>.Instance.BumpScheduleGeneration();
				debugger.LogEvent(Singleton<Time>.Instance.NowSeconds, cap, CapabilityCommonDefine.ECapabilityDebugEvent.OnDeactivated, null, null);
				debugger.EndActiveSpan(Singleton<Time>.Instance.NowSeconds, cap);
				return;
			}
			double now = Singleton<Time>.Instance.Now;
			try
			{
				cap.TickActive(dt);
			}
			catch (Exception err3)
			{
				this.LogError("TickActive", cap, err3);
			}
			debugger.LogEvent(Singleton<Time>.Instance.NowSeconds, cap, CapabilityCommonDefine.ECapabilityDebugEvent.TickActive, null, new double?(Singleton<Time>.Instance.Now - now));
		}

		// Token: 0x06045C57 RID: 285783 RVA: 0x01241464 File Offset: 0x0123F664
		private unsafe void LogError(string stage, Capability cap, object err)
		{
			Exception ex = err as Exception;
			if (ex != null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Capability;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "Capability 生命周期回调异常";
				Exception error = ex;
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("stage", stage);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("capability", cap.GetCapabilityId());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("error", ex.Message);
				instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return;
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Capability;
			ELogAuthor author2 = ELogAuthor.XDW;
			string message2 = "Capability 生命周期回调异常";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("stage", stage);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("capability", cap.GetCapabilityId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("error", err.ToString());
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		}

		// Token: 0x04027085 RID: 159877
		private readonly Stat StatTickGroup = Stat.Create("Capability.TickGroup", "", "");

		// Token: 0x04027086 RID: 159878
		private readonly Stat StatTickHostDefaultGroup = Stat.Create("Capability.TickHostDefaultGroup", "", "");

		// Token: 0x04027087 RID: 159879
		private readonly Stat StatCollectSchedule = Stat.Create("Capability.CollectSchedule", "", "");

		// Token: 0x04027088 RID: 159880
		private readonly Stat StatRunSchedule = Stat.Create("Capability.RunSchedule", "", "");

		// Token: 0x04027089 RID: 159881
		private readonly Stat StatPreTick = Stat.Create("Capability.PreTick", "", "");

		// Token: 0x0402708A RID: 159882
		private readonly Stat StatTickActive = Stat.Create("Capability.TickActive", "", "");

		// Token: 0x0402708B RID: 159883
		private readonly Stat StatTryActivate = Stat.Create("Capability.TryActivate", "", "");

		// Token: 0x0402708C RID: 159884
		private readonly Stat StatInterruptByTags = Stat.Create("Capability.InterruptByTags", "", "");
	}
}
