using AutoMapper;
using PolyDo.Application.DTOs;
using PolyDo.Domain.Entities;
using PolyDo.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyDo.Application.Services {
    public class SubTaskService : ISubTaskService {
        private readonly ISubTaskRepository subTaskRepository;
        private readonly IMapper mapper;

        public SubTaskService(ISubTaskRepository subTaskRepository, IMapper mapper) {
            this.subTaskRepository = subTaskRepository;
            this.mapper = mapper;
        }

        public async Task AddSubTaskAsync(SubTaskDto subTask) {
            var mapped = mapper.Map<SubTask>(subTask);
            await subTaskRepository.AddSubTaskAsync(mapped);
        }

        public async Task DeleteSubTaskAsync(int id) {
            await subTaskRepository.DeleteSubTaskAsync(id);
        }

        public async Task<IEnumerable<SubTaskDto>> GetAllSubTasksAsync() {
            var subTasks = await subTaskRepository.GetAllSubTasksAsync();
            var mapped = mapper.Map<IEnumerable<SubTaskDto>>(subTasks);

            return mapped;
        }

        public async Task<SubTaskDto> GetSubTaskByIdAsync(int id) {
            var subTasks = await subTaskRepository.GetSubTaskByIdAsync(id);
            var mapped = mapper.Map<SubTaskDto>(subTasks);

            return mapped;
        }

        public async Task UpdateSubTaskAsync(SubTaskDto subTask) {
            var mapped = mapper.Map<SubTask>(subTask);
            await subTaskRepository.UpdateSubTaskAsync(mapped);
        }
    }
}
