using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.GenericPrompt;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x0200700D RID: 28685
	[NullableContext(2)]
	[Nullable(0)]
	public class CommonTouchUiEditItem : ITouchUiEditItem, IStaticVariableResetter
	{
		// Token: 0x060456F7 RID: 284407 RVA: 0x01227822 File Offset: 0x01225A22
		static CommonTouchUiEditItem()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(CommonTouchUiEditItem.CreateStaticDefaultValue), new Action(CommonTouchUiEditItem.ResetStaticDefaultValue));
		}

		// Token: 0x1700A4C5 RID: 42181
		// (get) Token: 0x060456F8 RID: 284408 RVA: 0x01227841 File Offset: 0x01225A41
		// (set) Token: 0x060456F9 RID: 284409 RVA: 0x01227849 File Offset: 0x01225A49
		public ITouchUiEditData Data { get; set; }

		// Token: 0x1700A4C6 RID: 42182
		// (get) Token: 0x060456FA RID: 284410 RVA: 0x01227852 File Offset: 0x01225A52
		// (set) Token: 0x060456FB RID: 284411 RVA: 0x0122785A File Offset: 0x01225A5A
		[Nullable(1)]
		public UUIItem RootItem { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x060456FC RID: 284412 RVA: 0x01227864 File Offset: 0x01225A64
		[NullableContext(1)]
		public CommonTouchUiEditItem(UUIItem rootItem, [Nullable(2)] ITouchUiEditData data)
		{
			this.RootItem = rootItem;
			AActor owner = this.RootItem.GetOwner();
			UUIDraggableComponent uuidraggableComponent = owner.GetComponentByClass(UUIDraggableComponent.StaticClass()) as UUIDraggableComponent;
			UUIButtonComponent uuibuttonComponent = owner.GetComponentByClass(UUIButtonComponent.StaticClass()) as UUIButtonComponent;
			UUIExtendToggle uuiextendToggle = owner.GetComponentByClass(UUIExtendToggle.StaticClass()) as UUIExtendToggle;
			if (data != null && data.Editable)
			{
				this.RootItem.SetRaycastTarget(true);
				for (int i = 0; i < CommonTouchUiEditItem.disableChildCompClasses.Length; i++)
				{
					UClass classPtr = CommonTouchUiEditItem.disableChildCompClasses[i];
					TArray<UActorComponent> componentsInChildren = ULGUIBPLibrary.GetComponentsInChildren(owner, classPtr, false);
					for (int j = 0; j < componentsInChildren.Num(); j++)
					{
						UActorComponent uactorComponent = componentsInChildren.Get(j);
						AActor aactor = (uactorComponent != null) ? uactorComponent.GetOwner() : null;
						UUIItem uuiitem = ((aactor != null) ? aactor.GetComponentByClass(UUIItem.StaticClass()) : null) as UUIItem;
						if (uuiitem != null)
						{
							uuiitem.SetRaycastTarget(false);
						}
					}
				}
			}
			if (uuidraggableComponent == null && data != null && data.Editable)
			{
				uuidraggableComponent = (owner.AddComponentByClass(UUIDraggableComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as UUIDraggableComponent);
			}
			if (uuidraggableComponent != null)
			{
				uuidraggableComponent.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDrag));
				uuidraggableComponent.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragBegin));
				uuidraggableComponent.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragEnd));
			}
			if (uuibuttonComponent == null && data != null && data.Editable)
			{
				uuibuttonComponent = (owner.AddComponentByClass(UUIButtonComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as UUIButtonComponent);
			}
			if (uuibuttonComponent != null)
			{
				uuibuttonComponent.OnPointDownCallBack.Bind(new Action(this.OnButtonPress));
				uuibuttonComponent.OnPointUpCallBack.Bind(new Action(this.OnButtonRelease));
			}
			if (uuiextendToggle != null)
			{
				uuiextendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnExtendToggleStateChanged));
				uuiextendToggle.CanExecuteChange.Bind(new Func<bool>(this.OnCheckCanExecuteChange));
			}
			this.OriginalAnchorOffsetX = this.RootItem.GetAnchorOffsetX();
			this.OriginalAnchorOffsetY = this.RootItem.GetAnchorOffsetY();
		}

		// Token: 0x060456FD RID: 284413 RVA: 0x01227AD8 File Offset: 0x01225CD8
		public void SetData(ITouchUiEditData data)
		{
			this.Data = data;
			FVector lguispaceAbsolutePosition = this.RootItem.GetLGUISpaceAbsolutePosition();
			this.ResultLocation = new FVector(lguispaceAbsolutePosition.X + ((data != null) ? data.OffsetX : 0f), lguispaceAbsolutePosition.Y + ((data != null) ? data.OffsetY : 0f), lguispaceAbsolutePosition.Z);
			this.ApplyDataChange();
			this.CacheData(data);
		}

		// Token: 0x060456FE RID: 284414 RVA: 0x01227B44 File Offset: 0x01225D44
		private void CacheData(ITouchUiEditData data)
		{
			this.Cache = new ItemDataCache();
			this.Cache.OffsetX = ((data != null) ? data.OffsetX : 0f);
			this.Cache.OffsetY = ((data != null) ? data.OffsetY : 0f);
			this.Cache.Scale = ((data != null) ? data.Scale : 1f);
			this.Cache.Alpha = ((data != null) ? data.Alpha : 1f);
			this.Cache.HierarchyIndex = ((data != null) ? data.HierarchyIndex : 0);
		}

		// Token: 0x060456FF RID: 284415 RVA: 0x01227BE0 File Offset: 0x01225DE0
		public bool IsEdited()
		{
			MathUtils instance = Singleton<MathUtils>.Instance;
			ITouchUiEditData data = this.Data;
			double a = (double)((data != null) ? data.OffsetX : 0f);
			ItemDataCache cache = this.Cache;
			if (instance.IsNearlyEqual(a, (double)((cache != null) ? cache.OffsetX : 0f), new double?(0.01)))
			{
				MathUtils instance2 = Singleton<MathUtils>.Instance;
				ITouchUiEditData data2 = this.Data;
				double a2 = (double)((data2 != null) ? data2.OffsetY : 0f);
				ItemDataCache cache2 = this.Cache;
				if (instance2.IsNearlyEqual(a2, (double)((cache2 != null) ? cache2.OffsetY : 0f), new double?(0.01)))
				{
					MathUtils instance3 = Singleton<MathUtils>.Instance;
					ITouchUiEditData data3 = this.Data;
					double a3 = (double)((data3 != null) ? data3.Scale : 1f);
					ItemDataCache cache3 = this.Cache;
					if (instance3.IsNearlyEqual(a3, (double)((cache3 != null) ? cache3.Scale : 1f), new double?(0.01)))
					{
						MathUtils instance4 = Singleton<MathUtils>.Instance;
						ITouchUiEditData data4 = this.Data;
						double a4 = (double)((data4 != null) ? data4.Alpha : 1f);
						ItemDataCache cache4 = this.Cache;
						if (instance4.IsNearlyEqual(a4, (double)((cache4 != null) ? cache4.Alpha : 1f), new double?(0.01)))
						{
							MathUtils instance5 = Singleton<MathUtils>.Instance;
							ITouchUiEditData data5 = this.Data;
							double a5 = (double)((data5 != null) ? data5.HierarchyIndex : 0);
							ItemDataCache cache5 = this.Cache;
							return !instance5.IsNearlyEqual(a5, (double)((cache5 != null) ? cache5.HierarchyIndex : 0), new double?(0.01));
						}
					}
				}
			}
			return true;
		}

		// Token: 0x06045700 RID: 284416 RVA: 0x01227D5C File Offset: 0x01225F5C
		public void SetOffset(float x, float y)
		{
			float num = x - this.Data.OffsetX;
			float num2 = y - this.Data.OffsetY;
			if (num == 0f && num2 == 0f)
			{
				return;
			}
			this.ResultLocation.X = this.ResultLocation.X + num;
			this.ResultLocation.Y = this.ResultLocation.Y + num2;
			this.ResultLocation.Z = 0f;
			this.FixLocation(this.ResultLocation);
		}

		// Token: 0x06045701 RID: 284417 RVA: 0x01227DD2 File Offset: 0x01225FD2
		public void SetScale(float scale)
		{
			this.ScaleVector.X = scale;
			this.ScaleVector.Y = scale;
			this.ScaleVector.Z = scale;
			this.SetDataProperty("Scale", scale);
		}

		// Token: 0x06045702 RID: 284418 RVA: 0x01227E0C File Offset: 0x0122600C
		public void SetAlpha(float alpha)
		{
			if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)alpha, (double)this.Data.Alpha, null))
			{
				return;
			}
			this.SetDataProperty("Alpha", alpha);
		}

		// Token: 0x06045703 RID: 284419 RVA: 0x01227E4E File Offset: 0x0122604E
		public void SetHierarchyIndex(int index)
		{
			this.SetDataProperty("HierarchyIndex", index);
		}

		// Token: 0x06045704 RID: 284420 RVA: 0x01227E64 File Offset: 0x01226064
		public void OnViewDestroy()
		{
			AActor owner = this.RootItem.GetOwner();
			if (owner != null)
			{
				UUIDraggableComponent uuidraggableComponent = owner.GetComponentByClass(UUIDraggableComponent.StaticClass()) as UUIDraggableComponent;
				if (uuidraggableComponent != null)
				{
					uuidraggableComponent.OnPointerDragCallBack.Unbind();
					uuidraggableComponent.OnPointerBeginDragCallBack.Unbind();
					uuidraggableComponent.OnPointerEndDragCallBack.Unbind();
				}
				UUIButtonComponent uuibuttonComponent = owner.GetComponentByClass(UUIButtonComponent.StaticClass()) as UUIButtonComponent;
				if (uuibuttonComponent != null)
				{
					uuibuttonComponent.OnPointDownCallBack.Unbind();
					uuibuttonComponent.OnPointUpCallBack.Unbind();
				}
				UUIExtendToggle uuiextendToggle = owner.GetComponentByClass(UUIExtendToggle.StaticClass()) as UUIExtendToggle;
				if (uuiextendToggle != null)
				{
					uuiextendToggle.OnStateChange.Remove(new Action<EToggleState>(this.OnExtendToggleStateChanged));
					uuiextendToggle.CanExecuteChange.Unbind();
				}
			}
		}

		// Token: 0x06045705 RID: 284421 RVA: 0x01227F28 File Offset: 0x01226128
		[NullableContext(1)]
		private void SetDataProperty(string property, object value)
		{
			if (this.Data != null)
			{
				if (property == "Scale")
				{
					this.Data.Scale = (float)value;
				}
				else if (property == "Alpha")
				{
					this.Data.Alpha = (float)value;
				}
				else if (property == "HierarchyIndex")
				{
					this.Data.HierarchyIndex = (int)value;
				}
			}
			this.ApplyDataChange();
		}

		// Token: 0x06045706 RID: 284422 RVA: 0x01227FA4 File Offset: 0x012261A4
		private void ApplyDataChange()
		{
			if (this.RootItem != null && this.Data != null)
			{
				this.RootItem.SetAnchorOffsetX(this.OriginalAnchorOffsetX + this.Data.OffsetX);
				this.RootItem.SetAnchorOffsetY(this.OriginalAnchorOffsetY + this.Data.OffsetY);
				this.ScaleVector.X = this.Data.Scale;
				this.ScaleVector.Y = this.Data.Scale;
				this.RootItem.SetUIItemScale(this.ScaleVector);
				this.RootItem.SetUIItemAlpha(this.Data.Alpha);
				this.RootItem.SetHierarchyIndex(this.Data.HierarchyIndex);
				TouchUiEditViewModel.NotifySelectedItemChange(this);
			}
		}

		// Token: 0x06045707 RID: 284423 RVA: 0x01228070 File Offset: 0x01226270
		public void OnDrag(ULGUIPointerEventData eventData)
		{
			if (this.Data == null)
			{
				return;
			}
			FVector localOffsetVector = this.LocalOffsetVector;
			if (TouchUiEditViewModel.GetTouchFingerDataCount() >= 2)
			{
				return;
			}
			FVector localPointInPlane = eventData.GetLocalPointInPlane();
			FVectorDouble fvectorDouble = (eventData.dragComponent.GetOwner() as AUIBaseActor).D_GetActorScale3D();
			FVector fvector = fvectorDouble;
			float num = (localPointInPlane.X - this.LocalOffsetVector.X) * fvector.X;
			float num2 = (localPointInPlane.Y - this.LocalOffsetVector.Y) * fvector.Z;
			if (num == 0f || num2 == 0f)
			{
				return;
			}
			this.ResultLocation.X = this.ResultLocation.X + num;
			this.ResultLocation.Y = this.ResultLocation.Y + num2;
			this.ResultLocation.Z = 0f;
			this.FixLocation(this.ResultLocation);
			this.LocalOffsetVector = localPointInPlane;
		}

		// Token: 0x06045708 RID: 284424 RVA: 0x01228144 File Offset: 0x01226344
		public void OnDragBegin(ULGUIPointerEventData eventData)
		{
			this.LocalOffsetVector = eventData.GetLocalPointInPlane();
			FVector lguispaceAbsolutePosition = this.RootItem.GetLGUISpaceAbsolutePosition();
			this.ResultLocation = new FVector(lguispaceAbsolutePosition.X, lguispaceAbsolutePosition.Y, lguispaceAbsolutePosition.Z);
		}

		// Token: 0x06045709 RID: 284425 RVA: 0x01228186 File Offset: 0x01226386
		public void OnDragEnd(ULGUIPointerEventData eventData)
		{
			this.LocalOffsetVector = default(FVector);
		}

		// Token: 0x0604570A RID: 284426 RVA: 0x01228194 File Offset: 0x01226394
		private void OnButtonPress()
		{
			this.OnButtonPress(null);
		}

		// Token: 0x0604570B RID: 284427 RVA: 0x012281A0 File Offset: 0x012263A0
		public void OnButtonPress(ULGUIPointerEventData eventData)
		{
			if (this.Data == null)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("NotEdit", Array.Empty<object>());
				return;
			}
			this.LocalOffsetVector = default(FVector);
			FVector lguispaceAbsolutePosition = this.RootItem.GetLGUISpaceAbsolutePosition();
			this.ResultLocation = new FVector(lguispaceAbsolutePosition.X, lguispaceAbsolutePosition.Y, lguispaceAbsolutePosition.Z);
			TouchUiEditViewModel.SetCurrentSelectedItem(this);
		}

		// Token: 0x0604570C RID: 284428 RVA: 0x01228205 File Offset: 0x01226405
		private void OnButtonRelease()
		{
			this.OnButtonRelease(null);
		}

		// Token: 0x0604570D RID: 284429 RVA: 0x0122820E File Offset: 0x0122640E
		public void OnButtonRelease(ULGUIPointerEventData eventData)
		{
			this.LocalOffsetVector = default(FVector);
		}

		// Token: 0x0604570E RID: 284430 RVA: 0x0122821C File Offset: 0x0122641C
		public void OnExtendToggleStateChanged(EToggleState state)
		{
			if (this.Data == null)
			{
				return;
			}
			if (state != EToggleState.ETT_Checked)
			{
				return;
			}
			TouchUiEditViewModel.SetCurrentSelectedItem(this);
		}

		// Token: 0x0604570F RID: 284431 RVA: 0x01228234 File Offset: 0x01226434
		public bool OnCheckCanExecuteChange()
		{
			if (this.Data == null)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("NotEdit", Array.Empty<object>());
				return false;
			}
			ITouchUiEditItem currentSelectedItem = TouchUiEditViewModel.GetCurrentSelectedItem();
			return currentSelectedItem == null || currentSelectedItem != this;
		}

		// Token: 0x06045710 RID: 284432 RVA: 0x01228274 File Offset: 0x01226474
		private FVector ClampBound(FVector location)
		{
			double x = (this.RootItem.GetOwner() as AUIBaseActor).D_GetActorScale3D().X;
			FVector2D pivot = this.RootItem.GetPivot();
			float y = pivot.Y;
			float x2 = pivot.X;
			UUIItem rootItem = TouchUiEditViewModel.GetRootItem();
			float width = rootItem.Width;
			double height = (double)rootItem.Height;
			double num = (double)this.RootItem.Width * x;
			double num2 = (double)this.RootItem.Height * x;
			double min = 0.0 + num * (double)x2;
			double max = (double)width - num * (double)(1f - x2);
			double min2 = 0.0 + num2 * (double)y;
			double max2 = height - num2 * (double)(1f - y);
			location.X = (float)Singleton<MathUtils>.Instance.Clamp((double)location.X, min, max);
			location.Y = (float)Singleton<MathUtils>.Instance.Clamp((double)location.Y, min2, max2);
			return location;
		}

		// Token: 0x06045711 RID: 284433 RVA: 0x01228364 File Offset: 0x01226564
		private void FixLocation(FVector location)
		{
			FVector fvector = this.ClampBound(location);
			float anchorOffsetX = this.RootItem.GetAnchorOffsetX();
			float anchorOffsetY = this.RootItem.GetAnchorOffsetY();
			this.RootItem.SetLGUISpaceAbsolutePosition(fvector);
			float anchorOffsetX2 = this.RootItem.GetAnchorOffsetX();
			float anchorOffsetY2 = this.RootItem.GetAnchorOffsetY();
			this.Data.OffsetX += anchorOffsetX2 - anchorOffsetX;
			this.Data.OffsetY += anchorOffsetY2 - anchorOffsetY;
		}

		// Token: 0x06045712 RID: 284434 RVA: 0x012283E2 File Offset: 0x012265E2
		public static void CreateStaticDefaultValue()
		{
			CommonTouchUiEditItem.disableChildCompClasses = new TWeakObjectPtr<UClass>[]
			{
				UUIDraggableComponent.StaticClass().ToWeakClass(),
				UUISelectableComponent.StaticClass().ToWeakClass()
			};
		}

		// Token: 0x06045713 RID: 284435 RVA: 0x01228411 File Offset: 0x01226611
		public static void ResetStaticDefaultValue()
		{
			CommonTouchUiEditItem.disableChildCompClasses = null;
		}

		// Token: 0x04026CEE RID: 158958
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		private static TWeakObjectPtr<UClass>[] disableChildCompClasses;

		// Token: 0x04026CF0 RID: 158960
		private ItemDataCache Cache;

		// Token: 0x04026CF1 RID: 158961
		private FVector ScaleVector = new FVector(1f, 1f, 1f);

		// Token: 0x04026CF2 RID: 158962
		private FVector LocalOffsetVector;

		// Token: 0x04026CF3 RID: 158963
		private FVector ResultLocation;

		// Token: 0x04026CF4 RID: 158964
		private readonly float OriginalAnchorOffsetX;

		// Token: 0x04026CF5 RID: 158965
		private readonly float OriginalAnchorOffsetY;
	}
}
