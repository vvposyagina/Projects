#pragma once

#include "Common\StepTimer.h"
#include "Common\DeviceResources.h"
#include "Content\Sample3DSceneRenderer.h"
#include "Content\SampleFpsTextRenderer.h"

// Отрисовывает содержимое Direct2D и 3D на экране.
namespace Sorts
{
	class SortsMain : public DX::IDeviceNotify
	{
	public:
		SortsMain(const std::shared_ptr<DX::DeviceResources>& deviceResources);
		~SortsMain();
		void CreateWindowSizeDependentResources();
		void Update();
		bool Render();

		// IDeviceNotify
		virtual void OnDeviceLost();
		virtual void OnDeviceRestored();

	private:
		// Кэшированный указатель на ресурсы устройства.
		std::shared_ptr<DX::DeviceResources> m_deviceResources;

		// TODO: Замените это собственными визуализаторами содержимого.
		std::unique_ptr<Sample3DSceneRenderer> m_sceneRenderer;
		std::unique_ptr<SampleFpsTextRenderer> m_fpsTextRenderer;

		// Таймер цикла отрисовки.
		DX::StepTimer m_timer;
	};
}