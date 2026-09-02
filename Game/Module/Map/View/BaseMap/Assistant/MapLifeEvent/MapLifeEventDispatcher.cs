using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Map.View.BaseMap.Assistant.MapLifeEvent
{
	// Token: 0x02005801 RID: 22529
	[NullableContext(1)]
	[Nullable(0)]
	public class MapLifeEventDispatcher
	{
		// Token: 0x0603951D RID: 234781 RVA: 0x00E8D77E File Offset: 0x00E8B97E
		public MapLifeEventDispatcher(BaseMap map)
		{
			this.TargetExpressionMap = map;
			Dictionary<EMapLifeEventListenerType, MapLifeEventListener> dictionary = new Dictionary<EMapLifeEventListenerType, MapLifeEventListener>();
			dictionary[EMapLifeEventListenerType.SceneGameplayUnlock] = new MapSceneGameplayUnlock(this.TargetExpressionMap);
			this.Listeners = dictionary;
		}

		// Token: 0x0603951E RID: 234782 RVA: 0x00E8D7AC File Offset: 0x00E8B9AC
		public UniTask OnWorldMapBeforeStartAsync()
		{
			MapLifeEventDispatcher.<OnWorldMapBeforeStartAsync>d__3 <OnWorldMapBeforeStartAsync>d__;
			<OnWorldMapBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnWorldMapBeforeStartAsync>d__.<>4__this = this;
			<OnWorldMapBeforeStartAsync>d__.<>1__state = -1;
			<OnWorldMapBeforeStartAsync>d__.<>t__builder.Start<MapLifeEventDispatcher.<OnWorldMapBeforeStartAsync>d__3>(ref <OnWorldMapBeforeStartAsync>d__);
			return <OnWorldMapBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603951F RID: 234783 RVA: 0x00E8D7F0 File Offset: 0x00E8B9F0
		public void OnWorldMapBeforeShow()
		{
			foreach (KeyValuePair<EMapLifeEventListenerType, MapLifeEventListener> keyValuePair in this.Listeners)
			{
				EMapLifeEventListenerType key = keyValuePair.Key;
				MapLifeEventListener value = keyValuePair.Value;
				Dictionary<EMapLifeEventListenerType, IMapLifeEventTriggerParam> mapLifeEventListenerTriggerMap = ModelBase<MapModel>.Instance.MapLifeEventListenerTriggerMap;
				IMapLifeEventTriggerParam mapLifeEventTriggerParam;
				if (mapLifeEventListenerTriggerMap != null && mapLifeEventListenerTriggerMap.TryGetValue(key, out mapLifeEventTriggerParam) && mapLifeEventTriggerParam.State)
				{
					value.OnWorldMapBeforeShow();
				}
			}
		}

		// Token: 0x06039520 RID: 234784 RVA: 0x00E8D878 File Offset: 0x00E8BA78
		public void OnWorldMapAfterShow()
		{
			foreach (KeyValuePair<EMapLifeEventListenerType, MapLifeEventListener> keyValuePair in this.Listeners)
			{
				EMapLifeEventListenerType key = keyValuePair.Key;
				MapLifeEventListener value = keyValuePair.Value;
				Dictionary<EMapLifeEventListenerType, IMapLifeEventTriggerParam> mapLifeEventListenerTriggerMap = ModelBase<MapModel>.Instance.MapLifeEventListenerTriggerMap;
				IMapLifeEventTriggerParam mapLifeEventTriggerParam;
				if (mapLifeEventListenerTriggerMap != null && mapLifeEventListenerTriggerMap.TryGetValue(key, out mapLifeEventTriggerParam) && mapLifeEventTriggerParam.State)
				{
					value.OnWorldMapAfterShow();
				}
			}
		}

		// Token: 0x06039521 RID: 234785 RVA: 0x00E8D900 File Offset: 0x00E8BB00
		public void OnWorldBeforeDestroy()
		{
		}

		// Token: 0x0402095E RID: 133470
		[Nullable(2)]
		private readonly BaseMap TargetExpressionMap;

		// Token: 0x0402095F RID: 133471
		private readonly Dictionary<EMapLifeEventListenerType, MapLifeEventListener> Listeners;
	}
}
